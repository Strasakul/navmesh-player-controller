# Unity Package: NavMesh Agent Player Controller
## Description

This is a Unity Package for a 3rd Person Drag and Drop / Point and Click style navigation method for Unitys NavMesh System.
It also uses the Cinemachine System for the Camera.

This Navigation Methode workes best for Smartphone useage.

## Installation
1. Download:

	- Download the NavMesh Agent Player Controller Package or clone the repository.
2. Import into Unity:

	- Open your Unity project.
	- In the Project window, right-click in the Directory section.
	- Choose 'Import Package' -> 'Custom Package' and select the downloaded package.
3. Dependencies:

	- Ensure you have the Cinemachine and AI Navigation Packages installed. You can find them under 'Window' -> 'Package Manager' -> 'Unity Registry.' Search for the packages in the search bar.

## Usage
- The package includes a ready-to-use blueprint and two scripts.
- Drag and drop the Player Blueprint into your scene.
- Ensure a valid NavMesh is present, and the player is positioned on it.

For an Example setup, refer to the [Example Project](https://gitlab.maibornwolff.de/felix.link/navmesh-agent-player-controller/-/tree/main/Example%20Project?ref_type=heads).

## Configuration

Adjust the Camera speed using two variables in the Camera Controller script located at 'Player' -> 'Player Camera' -> 'CinemachineFreeLook':

- X Speed: 0.005
- Y Speed: 0.05

Note: Y speed should be higher for equivalent results.

## Example Project
Explore the [Example Project](https://gitlab.maibornwolff.de/felix.link/navmesh-agent-player-controller/-/tree/main/Example%20Project?ref_type=heads) for practical implementation.

## Prerequisites Example Project

- Unity version 2020.3.21 or higher 

## Feedback
We welcome your feedback! If you encounter issues or have suggestions for improvement, please report them.


