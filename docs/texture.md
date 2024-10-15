# Textures
You can apply textures to each classroom's floor, ceiling, and individual walls to change their appearance. The `Textures` class allows easy access to the library of textures. 

## Texture Library

| Texture | Code | Visual |
|---------|------|--------|
|Asphalt|`Textures.Asphalt`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Asphalt.png" width=150px height=150px>
|Bones|`Textures.Bones`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Bones.png" width=150px height=150px>
|Brick|`Textures.Brick`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Brick.png" width=150px height=150px>
|Cobblestone|`Textures.Cobblestone`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Cobblestone.png" width=150px height=150px>
|Forest|`Textures.Forest`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Forest.png" width=150px height=150px>
|Grass|`Textures.Grass`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Grass.png" width=150px height=150px>
|Ice|`Textures.Ice`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Ice.png" width=150px height=150px>
|Lava|`Textures.Lava`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Lava.png" width=150px height=150px>
|Sand|`Textures.Sand`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Sand.png" width=150px height=150px>
|Water|`Textures.Water`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Water.png" width=150px height=150px>
|Wood|`Textures.Wood`|<img title="Asphalt" src="https://github.com/adelphi-ed-tech/MakerUnity/raw/refs/heads/main/Assets/Resources/Textures/Wood.png" width=150px height=150px>

## Code Examples

```csharp

// an example on how to set the texture of a specific wall

Room403.SetWallTexture(Textures.Brick, 0); // set the first wall's texture to brick
Room403.SetWallTexture(Textures.Bones, 3); // set the fourth wall's texture to bones

// an example on how to set the texture of a floor

Room403.SetFloorTexture(Textures.Ice);

// an example on how to set the texture of a ceiling

Room403.SetCeilingTexture(Textures.Grass);
