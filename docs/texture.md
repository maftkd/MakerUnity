# Textures
You can apply textures to each classroom's floor, ceiling, and individual walls to change their appearance. The `Textures` class allows easy access to the library of textures. 

## Texture Library


|Asphalt|`textures.asphalt`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Asphalt.png">
|Bones|`textures.bones`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Bones.png">
|Brick|`textures.brick`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Brick.png">
|Cobblestone|`textures.cobblestone`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Cobblestone.png">
|Forest|`textures.forest`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Forest.png">
|Grass|`textures.grass`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Grass.png">
|Ice|`textures.ice`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Ice.png">
|Lava|`textures.lava`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Lava.png">
|Sand|`textures.sand`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Sand.png">
|Water|`textures.water`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Water.png">
|Wood|`textures.wood`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Wood.png">

## Code Examples

```csharp

// an example on how to set the texture of a specific wall

Room403.SetWallTexture(textures.brick, 0); // set the first wall's texture to brick
Room403.SetWallTexture(textures.bones, 3); // set the fourth wall's texture to bones

// an example on how to set the texture of a floor

Room403.SetFloorTexture(textures.ice);

// an example on how to set the texture of a ceiling

Room403.SetCeilingTexture(textures.grass);
