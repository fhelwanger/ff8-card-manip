# ff8-card-manip

Conversion of [pingval's ruby script](http://pingval.g1.xrea.com/psff8/research/index_en.html#zell-card) to C#.

I tried to keep the behavior the same so it's already familiar to people.

## Settings

Instead of editing the source code directly, the settings can be changed by editing the "settings.json" file.

```json
{
    "Base": 550, // Base index for search
    "Width": 400, // Search width
    "RecoveryWidth": 360, // Search width for recovery mode
    "CountingWidth": 100, // Search width for counting RNG mode
    "CountingFrameWidth": 40, // Frame width for counting RNG mode
    "EarlyQuistis": "pingval", // pingval or luzbelheim
    "AutofireSpeed": 12, // Autofire speed (determines the frame width)
    "DelayFrame": 285, // Number of frames between "Yes" and "Play"
    "RanksOrder": "ulrd", // Order in which the card ranks are input (u = up, l = left, r = right, d = down)
    "StrongHighlightCards": [ 103, 105 ], // Card ids to strong highlight (see CardTable.cs for ids)
    "HighlightCards": [ 21, 48, 53 ], // Card ids to highlight (see CardTable.cs for ids)
    "Order": "Reverse", // Reverse, Ascending or Descending
    "ConsoleFps": 60, // For rare card timer
    "Player": "zellmama", // Which player playing against, see PlayerTable.cs
    "Fuzzy": [ ".", "r", "o", "ro" ], // If do fuzzy search do find cards (r = input ranks, o = opening hands)
    "ForcedIncr": 10, // Number of RNG additions when "Play" is selected
    "AcceptDelayFrame": 3, // Number of frames after selecting "Play" that RNG additions stop
    "Prompt": "> " // The prompt string to display
}
```

## Download

You can get the latest version from the [releases](https://github.com/fhelwanger/ff8-card-manip/releases). Just download the `ff8-card-manip.zip` file and extract it.

## Build

For development, you need [netcore 3.1](https://dotnet.microsoft.com/download) to build this.

After installing, just run the `build.bat` file. Output will be in the `bin\Release\net461\publish` folder.
