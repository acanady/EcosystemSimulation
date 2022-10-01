# EcosystemSimulation
A simple natural selection ecosystem simulation built in Unity

#### Still image of simulation
![image](https://user-images.githubusercontent.com/19479468/193156991-d8dcb9df-1280-4e46-8804-bf21d473c4e2.png)

### Humble Beginnings
Using some licensed unity assets I created a world for my agents to live on. It's a large flat grassland plane with a watering hole in the center. At the moment animals will wander about aimlessly; foxes, if a mouse is within their sensory radius, will run towards them and "Eat" them. Mice, fully intending not to get eaten, will run away from one or multiple foxes chasing it, chosing the least dangerous path.
![Simulation](RunningSimulation.gif)

### Mouse Predator Avoidance
I started with a simple algorithm that used the position of the fox to calculate a direction vector away from the fox. The mouse used this vector and then moved in that direction. This, however, led to the mouse prioritizing only one predator and often running into the hungry mouth of another predator that so happened to be opposite the other fox. After a lot of trial and error I stumbled upon a simple solution while testing, I add together the position vectors of the foxes and then calculates the flee direction vector from the resultant vector. This is a very naive solution however and there are fox configurations that still result in the mouse running into another fox, however it's highly stable for a two fox system and only slightly off for a three fox system so I'll accept the issues for now. *I hope to fix this in the near future by having mice "learn" to flee via neural nets.*
![Mouse Avoidance](MouseAvoidanceAlgorithm.gif)
