# hello-microservice

A basic template for a Doppler microservice based on .NET with CI, CD, Code Formatting, Authentication, and other common practices in Doppler teams.

For the moment, it is only a kind of example. In the future, it could be converted into a _Yeoman_ or _dotnet new_ scaffolding template 🤷‍♂️.

## Context

We base our CI/CD process on Jenkins, Docker Hub, and Docker Swarm.

Jenkins generates the images based on [.doppler-ci](./.doppler-ci) (a symlink to [Jenkisfile](./Jenkinsfile)). We refer to these generated images in a Docker Swarm using an _auto-redeploy_ approach. The [Doppler Swarm repository](https://github.com/MakingSense/doppler-swarm) stores the configuration of our Docker Swarm.

You can find a detailed description of our Git flow and the relation with Docker Hub in [Doppler-Forms repository](https://github.com/MakingSense/doppler-forms/blob/master/README.md#continuous-deployment-to-test-and-production-environments), but basically, it is the following:

* Pull Requests generates images with tags like `pr-177` (`pr-{pull request id}`) and (`pr-{pull request id}-{commit id}`).

* Merging in `main` (or `master` in some repositories) generates images with tags like `main` and `main-60737d6` (`main-{commit id}`). In general, these images are deployed automatically into the QA environment.

* Resetting the branch `INT` generates images with tags like `INT` and `INT-60737d6` (`INT-{commit id}`). In general, these images are deployed automatically into the INT environment.

* Tagging with the format `v#.#.#` generates images with tags like `v1`, `v1.3`, `v1.3.0`, `v1.3.0_982c388`. In general, our Production environment refers to images with tags like `v1` (only the mayor), so, depends on that, these images could be deployed automatically to the Production environment.

## Run validations in local environment

The source of truth related to the build process is [.doppler-ci](./.doppler-ci) (a symlink to [Jenkisfile](./Jenkinsfile)). It basically runs docker build, so, you can reproduce jenkins' build process running `docker build .` or `sh ./verify-w-docker.sh`.

If you prefer to run these commands without docker, you can read [Dockerfile](./Dockerfile) and follow the steps manually.

## Features

* Base conventions for a .NET/C# project.

* Normalize to Linux line endings by default for all files (See [.editorconfig](./.editorconfig) and [.gitattributes](./.gitattributes)).

* Ignore from git and docker files with the convention that denotes secrets (See [.gitignore](./.gitignore) and [.dockerignore](./.dockerignore)).

* Prettier validation for all supported files.

* Editor Config validation using `dotnet-format` and `eclint`.

* Launch and debug settings for VS Code ([.vscode](./.vscode)) and Visual Studio ([launchSettings.json](./Doppler.HelloMicroserver/../Doppler.HelloMicroservice/Properties/launchSettings.json)).

* Custom color for VS Code (using [Peacock](https://marketplace.visualstudio.com/items?itemName=johnpapa.vscode-peacock&wt.mc_id=vscodepeacock-github-jopapa), see [settings.json](./.vscode/settings.json)).

* Format validation, build and test run in CI process.

* Generation of the docker images following Doppler convention and publish them to Docker Hub (See [build-n-publish.sh](./build-n-publish.sh)).

* Generation of `version.txt` file with the image version in `wwwroot`. Also, expose it using _static files_ middleware.

* [demo.http](./demo.http) to easily add manual tests for the exposed API with [VS Code REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client).

* Exposing only HTTP (not HTTPS) because that is the responsibility of our reverse proxy.

* Allow overriding project settings based on our Doppler conventions.

* Expose Swagger (with support for segment prefix)
