# Textures
You can apply textures to each classroom's floor, ceiling, and individual walls to change their appearance. The `Textures` class allows easy access to the library of textures. 

## Texture Library

| Texture | Code | Visual |
|---------|------|--------|
|Asphalt|`textures.asphalt`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Asphalt.png" width=150px height=150px>
|Bones|`textures.bones`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Bones.png" width=150px height=150px>
|Brick|`textures.brick`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Brick.png" width=150px height=150px>
|Cobblestone|`textures.cobblestone`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Cobblestone.png" width=150px height=150px>
|Forest|`textures.forest`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Forest.png" width=150px height=150px>
|Grass|`textures.grass`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Grass.png" width=150px height=150px>
|Ice|`textures.ice`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Ice.png" width=150px height=150px>
|Lava|`textures.lava`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Lava.png" width=150px height=150px>
|Sand|`textures.sand`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Sand.png" width=150px height=150px>
|Water|`textures.water`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Water.png" width=150px height=150px>
|Wood|`textures.wood`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Wood.png" width=150px height=150px>

## Code Examples

```csharp

// an example on how to set the texture of a specific wall

Room403.SetWallTexture(textures.brick, 0); // set the first wall's texture to brick
Room403.SetWallTexture(textures.bones, 3); // set the fourth wall's texture to bones

// an example on how to set the texture of a floor

Room403.SetFloorTexture(textures.ice);

// an example on how to set the texture of a ceiling

Room403.SetCeilingTexture(textures.grass);
