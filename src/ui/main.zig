const std = @import("std");
const clay = @import("zclay");
const rl = @import("raylib");
const renderer = @import("raylib_render_clay.zig");
const common = @import("PClusterCommon");
const PClusterConfig = common.PClusterConfig;

var config: PClusterConfig = .default;
const dark_gray: clay.Color = .{ 0x21, 0x21, 0x21, 255 };
const light_grey: clay.Color = .{ 224, 215, 210, 255 };
const red: clay.Color = .{ 168, 66, 28, 255 };
const orange: clay.Color = .{ 225, 138, 50, 255 };
const white: clay.Color = .{ 250, 250, 255, 255 };
const black: clay.Color = .{ 0, 0, 0, 255 };

pub fn main() !void {
    var debug_allocator: std.heap.DebugAllocator(.{}) = .init;
    defer _ = debug_allocator.deinit();
    const allocator = debug_allocator.allocator();

    const clay_memory = try allocator.alloc(u8, clay.minMemorySize());
    defer allocator.free(clay_memory);

    const clay_arena = clay.createArenaWithCapacityAndMemory(clay_memory);
    _ = clay.initialize(clay_arena, .{ .w = 1280, .h = 720 }, .{});
    clay.setMeasureTextFunction(void, {}, renderer.measureText);

    try renderer.loadFont(@embedFile("fonts/RobotoMono-Medium.ttf"), 0, 24);

    rl.setConfigFlags(.{
        .msaa_4x_hint = true,
    });
    rl.initWindow(1280, 720, "PCluster controll software");
    defer rl.closeWindow();
    rl.setTargetFPS(60);

    while (!rl.windowShouldClose()) {
        if (rl.isKeyPressed(.escape)) break;
        if (rl.isKeyPressed(.d)) clay.setDebugModeEnabled(!clay.isDebugModeEnabled());

        const mouse_position = rl.getMousePosition();
        clay.setPointerState(.{
            .x = mouse_position.x,
            .y = mouse_position.y,
        }, rl.isMouseButtonDown(.left));

        // clay.setLayoutDimensions(.{
        //     .w = @floatFromInt(rl.getScreenWidth()),
        //     .h = @floatFromInt(rl.getScreenHeight()),
        // });

        var timer = try std.time.Timer.start();
        clay.beginLayout();
        clay.UI()(clay.ElementDeclaration{
            .id = .ID("Background"),
            .background_color = dark_gray,
            .layout = .{
                .sizing = .{ .h = .grow, .w = .grow },
                .padding = .all(16),
                .child_alignment = .{
                    .x = .center,
                    .y = .center,
                },
            },
        })({
            clay.UI()(clay.ElementDeclaration{
                .id = .ID("Clusters"),
                .layout = .{
                    .child_gap = 8,
                    .padding = .all(8),
                },
                .corner_radius = .all(8),
                .background_color = .{ 0, 0, 0, 40 },
            })({
                for (0..4) |i| {
                    layoutDial(@intCast(i));
                }
            });
        });
        var render_commands = clay.endLayout();
        const ns = timer.lap();
        std.debug.print("clay layout time: {d}us\n", .{ns / std.time.ns_per_us});

        rl.beginDrawing();
        try renderer.clayRaylibRender(&render_commands, allocator);
        rl.endDrawing();
    }
}

pub fn layoutDial(index: u32) void {
    const width = 200;
    const height = 200;

    clay.UI()(clay.ElementDeclaration{
        .id = .IDI("Dial", @intCast(index)),
        .layout = .{
            .sizing = .{ .h = .fixed(width), .w = .fixed(height) },
            .direction = .top_to_bottom,
            .child_alignment = .{
                .x = .center,
            },
            .child_gap = 8,
            .padding = .all(8),
        },
        .corner_radius = .all(16),
        .background_color = black,
    })({
        // Numbers
        clay.UI()(clay.ElementDeclaration{
            .layout = .{
                .sizing = .{
                    .w = .fixed(180),
                    .h = .fixed(180),
                },
                .child_alignment = .{
                    .x = .center,
                    .y = .center,
                },
            },
            .corner_radius = .all(90),
            .border = .{
                .color = pclusterConfigColorToClayColor(config.dial.color, 255),
                .width = .all(3),
            },
            .background_color = .{ 50, 50, 50, 50 },
        })({
            // Black button over needle
            clay.UI()(clay.ElementDeclaration{
                .floating = .{
                    .zIndex = 1,
                    .attach_to = .to_parent,
                    .attach_points = .{
                        .parent = .center_center,
                        .element = .center_center,
                    },
                },
                .layout = .{
                    .sizing = .{
                        .w = .fixed(40),
                        .h = .fixed(40),
                    },
                },
                .corner_radius = .all(20),
                .background_color = black,
            })({});

            // Needle
            clay.UI()(clay.ElementDeclaration{
                .floating = .{
                    .attach_points = .{ .element = .center_center, .parent = .center_center },
                    .attach_to = .to_parent,
                    .offset = .{
                        .x = -32,
                        .y = 0,
                    },
                },
                .layout = .{
                    .sizing = .{
                        .h = .fixed(6),
                        .w = .fixed(70),
                    },
                },
                .background_color = pclusterConfigColorToClayColor(config.needle.color, 255),
            })({});
        });

        // Oled display
        const oled_border_radius = 2;
        clay.UI()(clay.ElementDeclaration{
            .floating = .{
                .attach_to = .to_parent,
                .offset = .{
                    .x = (width - 128) / 2 + oled_border_radius,
                    .y = height - 40 + oled_border_radius,
                },
            },
            .border = .{
                .width = .all(oled_border_radius),
                .color = white,
            },
            .layout = .{
                .sizing = .{
                    .w = .fixed(128),
                    .h = .fixed(32),
                },
                .child_alignment = .{
                    .y = .center,
                    .x = .center,
                },
            },
            .background_color = .{ 15, 15, 15, 255 },
        })({
            const text = switch (config.displays[index]) {
                .off => "",
                .cpu_usage => "CPU %",
                .cpu_temperature => "CPU Temp",
                .mem_usage => "MEM %",
                .gpu_usage => "GPU %",
                .gpu_temperature => "GPU Temp",
                else => {
                    std.log.err("Unsupported display information\n", .{});
                    std.process.exit(1);
                },
            };

            clay.text(text, .{
                .color = white,
                .font_size = 24,
                .alignement = .center,
            });
        });
    });
}

pub fn pclusterConfigColorToClayColor(color: PClusterConfig.Color, opacity: f32) clay.Color {
    return .{ @floatFromInt(color.r), @floatFromInt(color.g), @floatFromInt(color.b), opacity };
}
