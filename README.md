# Immersive Procedurally Generated Landscape

Name: Sean McGregor

Student Number: C18426032

Class Group: DT211c/4 or TU857/4

# Description of the project
The initial aim of my project was to portray a beautiful procedurally generated world which the user could wander and explore. I aimed for it to be an immersive, natural landscape, featuring a simple art style. I also aimed to include some animals in the surroundings. After completing development, I can confidently say that I achieved what I set out to. Below are some key parts of my project:

- Implements perlin noise in order to procedurally generate terrain.

- Facilitates switching between multiple different characters and player models.

- Uses a VFX object in order to conceal the transition between player models and make it look magical.

- Features a simple art style, whilst implementing HDRP and appearing natural and beautiful.

- Features seabirds which fly overhead and squawk naturally.

- Features immersive audio sources.

# Instructions for use
The Unity engine is needed in order to run this project. The resources needed are available [here](https://unity.com/download).

You can run the following command in your command line or terminal in order to download the project:
```
git clone https://github.com/sean-mcgregor/ge-project-2021-2022.git
```

Run the Unity Hub and click the *ADD* button. Locate the project folder and open it. When finished importing, you can run the project with the Unity engine. Press the play button and you can start to control your character. Make sure to turn your volume up! Try using headphones for 3D audio.

Once the game is running, you can use the W, A, S, and D keys to control your player and explore the world. You can stop the game using the Play button again, or alternatively the pause button.

# How it works
The Unity engine is used to run C# code which I have written.

The project consists of multiple different models, each of which have scripts associated with them and controlling them.

![image](https://user-images.githubusercontent.com/55545448/146172396-42e01843-cf2f-4f28-b693-ba36312277e4.png)

Image of script used to changed character, as displayed in Unity engine

The main part of the project is the procedurally generated terrain. It is generated using Perlin noise. In the Update() function, which is called once per frame, the next row of terrain is generated, and the terrain is shifted slightly on the X axis. This is done using the offset value.

```cs
void Update()
{
	Terrain terrain =  GetComponent<Terrain>();                 // Getting terrain object
	terrain.terrainData = GenerateTerrain(terrain.terrainData); // Generating new terrain data
	terrain_offset_x = terrain_offset_x + 0.01f;
}
```

The player also changes between character depending on the type of terrain they are on (water or land). This is done by checking the location of the player on the Y axis. The player changes model when they enter a new terrain. The change of character is concealed by a visual effect. This visual effect is also paired with audio.

```cs
// Checks if the player if newly on water
if (onWater && !onWaterLastFrame)
{
	switchCharacter(boatModel);
}
// Checks if the player is newly on land
else if (!onWater && onWaterLastFrame)
{
	switchCharacter(trainModel);
}
```

The two characters which the player can change between are the train character and the boat character. 

![image](https://user-images.githubusercontent.com/55545448/146170223-bc1db72f-c17b-4135-9f7e-4779743a0c09.png)

Image of Train Model

![image](https://user-images.githubusercontent.com/55545448/146170705-6f4c40ef-c4db-4640-a6cd-279b736b11f4.png)

Image of Boat model

Audio is also a large part of the project, as I wanted to ensure that it was an immersive environment. Each player model has its own unique sounds associated with it. The audio is achieved using audio sources which are attached to multiple objects, as well as an audio listener which is attached to the player. I blended 2 audio sources together to achieve the desired effect of the boat model. These audio sources are the sound of the water and the sound of engine humming. Additionally, when the player is in the vicinity of seabirds, they get louder and the sound is directional.

![image](https://user-images.githubusercontent.com/55545448/146171758-98981fbf-8602-45ca-be87-6bf549610350.png)

Image of seabird model

# List of classes/assets in the project and whether made yourself or modified or if its from a source, please give the reference
| Class/asset | Source |
|-----------|-----------|
| BoatModel.prefab | Created by me |
| ChangeCharacter.cs | Self written |
| Cloud.prefab | Created by me |
| CloudMover.cs | Self written |
| CloudSpawner.cs | Self written |
| Seagull.prefab | Created by me |
| SeagullController.cs | Self written |
| TerrainGenerator.cs | Modified from Sean's lecture notes |
| ThirdPersonMovement.cs | Modified from [Brackeys](https://www.youtube.com/watch?v=4HpC--2iowE) |
| TrainModel.prefab | Created by me |
| TrainPoof.vfx | Modified from [this youtube video](https://www.youtube.com/watch?v=sodiK1DzcwM) |

# References
- [Brackeys](https://www.youtube.com/channel/UCYbK_tjZ2OrIZFBvU6CCMiA)
- [edit](https://www.youtube.com/watch?v=sodiK1DzcwM)
- [Unity Forums](https://forum.unity.com/)
- [Bryan Duggan Lectures](https://github.com/skooter500/GE1-2021-2022)
- [Proposal Ref. #1](https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/)
- [Proposal Ref. #2](https://medium.com/@glazychevaeo/unity3d-procedural-generated-low-poly-terrain-d11914ab9f71)
- [Readme Cheatsheet](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet#links)

# What I am most proud of in the assignment
I entered this assignment panicked and uncomfortable. I had *no* experience ever with Unity or with C# in general. I really did not enjoy the initial days of development and I was very worried that I was incapable of developing a project which I would be proud to demo. However, with some perseverance, I found myself becoming more fond of Unity and of game development in general. As I became more familiar with Unity's user interface as well as the style of programming and Object relationships, my project developed from something incredibly basic to something which I was very proud to put my name to.

I am most proud of the development of my general Unity and C# skills development over time, as I saw myself transition from watching tutorials on the most basic of concepts, to developing my own code and scripts without any assistance. I am specifically proud of the transition between player characters, which I implemented myself and had the idea of without any tutorials or aid. This is the code which I wrote to implement that:

```cs
// Changes from currentModel to the model which is passed in
void switchCharacter(GameObject nextCharacter)
{
	transitionVisualPoof.Play();    // Playing the visual playermodel transition effect
	transitionSound.Play();         // Playing the audio for transition effect
	
	// Gets the direction which the player is currently facing
	Vector3 rotation = new Vector3(0, Player.transform.localRotation.eulerAngles.y, 0);
	
	Destroy(currentModel); // Destroying the current player model

	// Instantiating the new player model using the location and look rotation of the player 
	currentModel = Instantiate(nextCharacter, Player.transform.position, Quaternion.Euler(rotation));

	// Setting the new player model as a child of the Player object,
	// so that it moves and responds to user input
	currentModel.transform.SetParent(Player.transform);
}
```

# Proposal submitted earlier can go here:
This project will feature a beautiful procedurally generated world which the user can wander and explore. It will look like an immersive, natural, landscape, but feature a simple art style. There will be some animals to see around the landscape, too.

References I found to help me are:

	https://gamedevacademy.org/complete-guide-to-procedural-level-generation-in-unity-part-1/ 
and 
	https://medium.com/@glazychevaeo/unity3d-procedural-generated-low-poly-terrain-d11914ab9f71
