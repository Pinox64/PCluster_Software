# PCluster — USB Needle Gauge Hardware Monitor

PCluster is a multi-purpose needle gauge display featuring 4 analog dials and 4 small OLED screens used as dynamic labels. When connected to a computer, PCluster displays real-time system information using a physical, mechanical interface.

This repository contains the platform-specific software required to communicate with the PCluster hardware.

## Features

- USB HID interface (no OS driver required)
- Real-time hardware monitoring
- Four fully controllable needle gauges
- Four dynamic label screens
- Lightweight Linux backend + UI
- Separate Windows and Linux implementations
- Source-available with protections against commercial cloning

## Project Structure

```
/linux_src
/windows_src
```

## Installation (Linux)

1. Place `PCluster_Backend`, `PCluster_UI`, and `install.sh` together.
2. Make installer executable:

```
chmod +x install.sh
```

3. Run installer:

```
sudo ./install.sh
```

Backend installs to `/usr/local/bin` and runs as `pcluster_backend.service`.

Start UI:

```
PCluster_UI
```

## Managing Backend

```
systemctl status pcluster_backend.service
systemctl stop pcluster_backend.service
systemctl start pcluster_backend.service
systemctl disable pcluster_backend.service
```

## Installation (Windows)

Download the Windows version from Releases and run `PCluster.exe`.

## License

Licensed under **MIT + Commons Clause**.

### Allowed:
- Commercial use
- Modification, forking, personal or internal business use
- Free redistribution

### Not allowed:
- Selling the software
- Including it in a paid product
- Selling modified versions
- Using it to create a competing commercial hardware/software product

---

## Full License Text

MIT License

Copyright (c) <YEAR> <YOUR NAME>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

---------------------------------------------------------------------------
Commons Clause License Condition v1.0

The Software is provided to you under the MIT License subject to the following
Commons Clause condition.

The grant of rights under the MIT License does not include, and the Licensee
is prohibited from, selling the Software. For the purposes of this License,
“selling” means practicing any or all of the rights granted to you under the
License to provide to third parties, for a fee or other consideration, a
product or service whose value derives entirely or substantially from the
functionality of the Software. Any such “selling” is strictly prohibited.

This License allows commercial use but prohibits selling the Software or
including it in a paid product.
