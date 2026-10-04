# Scribble Tales

A two-player reading game for children aged 6–9 and a parent: one reads the story aloud, the other draws the scene, and together they choose how the story continues. Saxion *Project Start Up*, Nov–Dec 2022, team Lucky Lizards (6 people). I was the team's only programmer and wrote all of the game's code, about 2,200 lines.

<p align="center"><a href="https://youtu.be/ne49ZGRWPuo"><img src="https://img.youtube.com/vi/ne49ZGRWPuo/maxresdefault.jpg" width="100%" alt="Watch the Scribble Tales video"></a><br><sub>▸ <a href="https://youtu.be/ne49ZGRWPuo">Watch the video</a></sub></p>

## What I built

- A story box that loads each chapter from text files at runtime, with word-by-word, then letter-by-letter text animation and a speed slider
- Branching story choices, a drawing timer with pop-ups, and an end-of-story screen
- A language switch with English and Romanian story files
- Level select, scene fades, main menu, settings and audio with volume sliders
- An in-game testing tool and a test scene for the team

The story, art and pitch were made by the rest of the team.

Scripts: [`StoryGame/Assets/Scripts`](StoryGame/Assets/Scripts) · Unity 2021.3

`Unity` `C#` `UI` `Localization` `Runtime content loading`
