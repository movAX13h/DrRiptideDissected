# Dr. Riptide Dissected
Tool produced during reverse engineering the DOS game *"In Search of Dr.Riptide"*.

## Features
 - load game DAT file
 - display assets of DAT file: 
   - animated sprites (L)
   - maps with entity indicators and special positions (M)
   - images (PCX)
   - texts (TXT)
   - play game music using Adlib/CMF player by srtuss
 - display map palette inclusive palette rotation
 - display tile set of a map
 - list of all entities of a map
 - list of all triggers/special positions of a map
 - edit all assets (hex-editor) and save changes back to DAT
 - export all raw assets to a directory
 - export all/single sprites/images as animated GIF/PNG

## Formats

The game and formats were reverse engineered by srtuss and movAX13h in february 2018.
The [map file format](https://github.com/movAX13h/DrRiptideDissected/blob/master/mapfile%20anatomy%20by%20srtuss.txt) was reverse engineered by srtuss.
Some information necessary for a remake of the game is [hardcoded in the exe](https://github.com/movAX13h/DrRiptideDissected/blob/master/Tool/Riptide/Game.cs).

## Download
https://github.com/movAX13h/DrRiptideDissected/releases

## Using
HexBox (.NET Forms Control) https://sourceforge.net/projects/hexbox/

## Screenshots

### Maps
Zoomable, background tiles, entities and triggers:
![image](https://user-images.githubusercontent.com/1974959/36821383-1427d0a4-1cf3-11e8-8531-757835401b37.png)

Entites/shootables of a map:
![image](https://user-images.githubusercontent.com/1974959/36821569-d151750e-1cf3-11e8-8142-ed013736ba20.png)

Tiles of a map:
![image](https://user-images.githubusercontent.com/1974959/36821619-197d7fe4-1cf4-11e8-9775-5a8d88289d6f.png)

Special positions of a map:
![image](https://user-images.githubusercontent.com/1974959/36821661-56e2f558-1cf4-11e8-9570-c59527f10cb3.png)

Palette with realtime display of palette rotation of a map (not animated in the screenshot):
![image](https://user-images.githubusercontent.com/1974959/36821672-682a6166-1cf4-11e8-88ac-d805f4e504dc.png)

### Image viewer (PCX)
![image](https://user-images.githubusercontent.com/1974959/36821725-ba931128-1cf4-11e8-9a59-52c9f3ab5f91.png)

### Sprite viewer
Click through frames of a sprite animation, export to animated GIF or static PNG:
![image](https://user-images.githubusercontent.com/1974959/36821765-e5e9178c-1cf4-11e8-967a-6d5cf828b121.png)

### HEX-Editor for all assets
Saves changes back to the DAT file for low-level editing
![image](https://user-images.githubusercontent.com/1974959/36821889-8e8a1332-1cf5-11e8-951b-3a2f6ff7f4cc.png)
