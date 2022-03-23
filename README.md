# Parallel TPL

![workflow](https://github.com/epomatti/parallel-tpl/actions/workflows/dotnet.yml/badge.svg)

Parallel computation across CPU cores using .NET Core and TPL.

This image is partitioned in according the available CPUs for parallel work.

<img src="input/car.jpeg" width=400>

The result are the image parts processed in individual cores.

<img src=".docs/output.png" width=300>

## Running the code

If running on Linux you'll need this library:

```sh
sudo apt-get update
sudo apt-get install -y libgdiplus
```

Install and run:

```sh
dotnet restore
dotnet run
```

This will take a while. When finished, check the `output` directory.

<hr>

Unfortunately, the drawing library is [no longer fully supported](https://docs.microsoft.com/en-us/dotnet/core/compatibility/core-libraries/6.0/system-drawing-common-windows-only) on non-Windows and it is recommended to migrate to a cross-OS library.