const std = @import("std");
const common = @import("PClusterCommon");
const PClusterConfig = common.PClusterConfig;
const SystemInformation = common.SystemInformation;
const Mutexed = common.Mutexed;

const PCluster = switch (@import("builtin").os.tag) {
    .linux => @import("linux/PCluster.zig"),
    .windows => @import("windows/PCluster.zig"),
    .macos => @import("macos/PCluster.zig"),
    else => @compileError("Not implemented"),
};

pub fn main() !void {
    var debug_allocator: std.heap.DebugAllocator(.{}) = .init;
    defer _ = debug_allocator.deinit();
    const allocator = debug_allocator.allocator();
    _ = allocator;

    var pcluster = Mutexed(PCluster).init(try .init(.default));
    var sys_info: SystemInformation = .init;

    const config_listener_thread = try std.Thread.spawn(.{}, configUpdaterTask, .{&pcluster});
    defer config_listener_thread.detach();

    // TODO: Error handling
    while (true) {
        try sys_info.updateAll();
        for (0..20) |_| {
            try pcluster.acquire().writeReport(sys_info);
            pcluster.release();
            std.Thread.sleep(std.time.ns_per_ms * 10);
        }
        std.Thread.sleep(std.time.ns_per_ms * 3800);
    }
}

pub fn configUpdaterTask(pcluster: *Mutexed(PCluster)) !void {
    const localhost = comptime std.net.Address.parseIp("127.0.0.1", common.default_port) catch unreachable;
    var server = localhost.listen(.{ .reuse_port = true, .reuse_address = true, .kernel_backlog = 1 }) catch |e| {
        std.debug.print("Error while starting server: {}, exiting...\n", .{e});
        std.process.exit(1);
    };

    while (true) {
        const client = try server.accept();

        while (true) {
            // TODO: listen for commands, not just raw configs
            const config = PClusterConfig.readFrom(client.stream.reader()) catch break;
            pcluster.acquire().config = config;
            pcluster.release();
        }
    }
}
