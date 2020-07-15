# Introduction
This repository contains an example web portal for a hypothetical animal adoption agency for the purposes of the DevOps Azure Sprint Series. This code has been intentionally developed as a simple demonstration and should not be used as a base for any production development. For more information on how to develop microservices and .NET Core services please refer to the following links.

- [.NET Architecture Guides](https://dotnet.microsoft.com/learn/dotnet/architecture-guides)
- [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers)


# Instructions

Install the following prerequisites:
- [.NET Core 3.1 SDK](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- [NodeJS LTS](https://nodejs.org/en/download/)
- [Visual Studio Code](https://visualstudio.microsoft.com/downloads/)
- [Git](https://git-scm.com/download/win)

Clone the Git repository. **Ensure that the destination path contains no spaces.** If your path contains spaces you may get issues generating metadata files on build.

This application has been developed with Windows 10 however with a few tweaks it will work within MacOS environments as well. Talk to your coach if you do not have Windows installed for more information.

Unfortunately due to the wide variety of Linux configurations we are unable to support Linux users with their specific environment setup. We recommend using a free [Windows Virtual Machine for development.](https://developer.microsoft.com/en-us/windows/downloads/virtual-machines/)

Run the "run-all.cmd" to run the application locally. Note that you will not be able to debug the solution if another instance of the service is already running.

When the services are running you can view and interact with the front end portal [here](https://localhost:9001).

## Front End
- Built in .NET Core 3.1
- Static website using TypeScript and React

## Image Service
- Built in .NET Core 3.1
- Serves up images of specific animals

## Identity Service
- Built in .NET Core 3.1
- Authenticates a user that selects the correct animal given a picture

## Cart Service
- Built in .NET Core 3.1
- Handles cart state for what animals the user would want to update

## Animal Information Service
- Built in .NET Core 3.1
- Lists avaliable animals for adoption


# Updating this repository
This repository is normally imported to Azure DevOps. If you need to update your cloned instance with the latest code in GitHub, run the following commands in a terminal window below. Note that if the GitHub remote already exists, you can skip the step to add the remote.

```batch 
git remote add github https://github.com/awaregroup/animal-adoption-portal
git pull github master`
```


