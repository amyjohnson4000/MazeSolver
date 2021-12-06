# MazeSolver
Simple program to solve a maze.

Build Instructions:
Download Visual Studio 2022, Community download (free).  Open the solution in Visual Studio, click build, then click debug, start without debugging.

Analysis Questions:
1) It would not solve a maze with a loop, since it could potentially get stuck in that loop.
2) The solution's time complexity is O(3^(N^2)).  The solution's space complexity is O(N^2).  If we could somehow not have to check every grid space, or not make up to 3 calls per 
   grid space, this could reduce the time or space complexity.  I am not sure how to do that, though.
3) User Stories:
      1) Find the empty space with 3 consecutive open grids below it
      2) Move down an open hallway
      3) Successfully navigate open rooms
      4) Move around turns, with properly spaced "rooms" for turning
      5) Handle dead ends, where there is not enough "room" space for the ship to turn
