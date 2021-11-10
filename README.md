# fikmat-api-wrapper-unity

Simple Unity wrapper for [Fikmat API](https://github.com/fikmatt/fikmat-api)  
It deals with request sending automatically, you just update the data and they will be processed with next request in queue.

_it should work but I don't usually work with Unity & C#, so feel free to make a pull request with improvements_

### How to use
- attach the script to empty GameObject in your scene
- then you can access it via `FikmatApi.instance`

### Available functions
- SetLedLeft
- SetLedRight
- SetVibrate

### Examples
```
int[][] colors = new int[3][];
colors[0] = new int[3] { 255, 0, 0};
colors[1] = new int[3] { 0, 255, 0};
colors[2] = new int[3] { 0, 0, 255};

FikmatApi.instance.SetLedRight(colors);
FikmatApi.instance.SetLedRight(colors);

FikmatApi.instance.SetVibrate(99);
```
