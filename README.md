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

The fox is the predator in the simulation and at the top of the food chain. Like the mice they also have 4 traits that they inherit from their parents. These traits have a slight chance (configuragle) to "mutate" (increase or decrease) between generations.

### Running Some Simulations

Whats the worth of a simulation without some interesting tests. I extracted the data that was stored in the simulation and wrote it to a csv file so that it could
be more easily visualized. Below you can see 4 seperate tests with gene variation turned off and only the prey present in the simulation (predators were turned off for these tests). As you can see in 2 of the 4 simulations the mice went extinct.

![image](https://user-images.githubusercontent.com/19479468/194175021-65471f5c-4f07-47b4-a9b0-7d7d9fad6056.png)

Here i ran simulations involving the sensory radius gene, I've provided the code that accounts for the chance of genetic variance as well.

![image](https://user-images.githubusercontent.com/19479468/194175560-6e9ef8b4-a796-4f46-aeaa-7f06ffc9ed90.png)

![image](https://user-images.githubusercontent.com/19479468/194175397-00256a94-b844-4545-b4f5-4ab1413fb948.png)

Unsurprisingly we see an upward trend in the size of the sensory radius as time goes on, the sensory radius directly results in the prey being able to find food and (when present) avoid predators, these mice who are able to see more about their surroundings were able to out perform those more short sighted mice. It's also important ot notice that the mouse population in this simulation appears to have a slight upward growth, perhaps over time we would see a more stable population than we did previously since these mice were better suited to the environment.

***

Check out my other projects on my [website](https://acanady.github.io/#projects)

