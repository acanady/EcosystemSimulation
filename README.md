# EcosystemSimulation
A simple natural selection ecosystem simulation built in Unity

#### Still image of simulation
![image](https://user-images.githubusercontent.com/19479468/193156991-d8dcb9df-1280-4e46-8804-bf21d473c4e2.png)

### Humble Beginnings
Using some licensed unity assets I created a world for my agents to live on. It's a large flat grassland plane with a watering hole in the center. At the moment animals will wander about aimlessly; foxes, if a mouse is within their sensory radius, will run towards them and "Eat" them. Mice, fully intending not to get eaten, will run away from one or multiple foxes chasing it, chosing the least dangerous path.

![Simulation](RunningSimulation.gif)

### Mouse Predator Avoidance
I started with a simple algorithm that used the position of the fox to calculate a direction vector away from the fox. The mouse used this vector and then moved in that direction. This, however, led to the mouse prioritizing only one predator and often running into the hungry mouth of another predator that so happened to be opposite the other fox. After a lot of trial and error, I stumbled upon a simple solution while testing; I add together the position vectors of the foxes and then calculate the flee direction vector from the resultant vector. This is a very naive solution however, and there are fox configurations that still result in the mouse running into another fox. Despite this, it's highly stable for a two fox system and only slightly off for a three fox system, so I'll accept the issues for now. *I hope to fix this in the near future by having mice "learn" to flee via neural nets.*

![Mouse Avoidance](MouseAvoidanceAlgorithm.gif)

![Mice](mouseInfo.gif)

The mouse is the prey in this simulation and is at the bottom of the food chain. They eat berries that grow in the sim and reproduce when satisfied and their reproduction timers have hit 0. These 4 traits pictured are the traits that can vary in the simulation across different generations. As the mice continue to reproduce their offspring are better adapted to survive in the environment I created.

* **Sensory radius:** ```int``` value that controls the radius of which the mouse can see
* **Speed:** ```float``` value that controls how fast the entity moves (a higher speed makes them hungrier faster)
* **Hunger:** ```int``` value that controls how much a mouse can eat, a mouse that can eat alot can go longer without eating
* **Litter Count:** ```int``` value that controls how many offspring a mouse has at once.

![Foxes](foxInfo.gif)
The fox is the predator in the simulation and at the top of the food chain. Like the mice they also have 4 traits that they inherit from their parents. These traits have a slight change (configuragle) to "mutate" (increase or decrease) 
