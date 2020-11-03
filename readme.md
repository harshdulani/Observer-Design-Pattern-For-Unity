Why I felt the need to learn this:
Creating references to components in code doesn't lead to any complex problems for small scale projects. But as the project complexity increases, and the number of components that need to execute code at certain game states increases, coupling between code increases a lot.
Issues arise such as:
	a. Interdependence between otherwise unconnected mechanisms and systems
	b. Debugging becomes a pain because it does not make any sense why, say, the Player movement class has references to UI elements.
	c. Multiple systems seem broken in cases where simple conditional requirements aren't met.
	
The Observer Design Pattern is wonderful for helping solve this problem. Instead of having every component have references to every component, nobody has of no one.
Instead, a new heirarchy is introduced:

1. event library/manager - stores the event declaration & a wrapper function for event invoke()s
2. event listener - calls the events at required time
3. event dispatcher - announces the event

An example from this demo:

1. DoorEvents is a singleton class that declares and holds invokation functions for all Door Related Events. (similarly for PickupEvents)

2. DoorController class that defines the behaviour of the events such as DoorOpen and DoorClose, which are called everytime the player enters the Trigger Area for the door.

3. DoorTriggerArea class that knows the conditional requirements/situations when the events need to be called and hence calls them.

Summary:

Instead of all (contextually) unimportant/irrelevant Behaviours(classes) telling other behaviours what to do when they come to know of "Events"/conditional requirements, they tell it to a "Supervisor" of sorts (for e.g: DoorEvents). 
This supervisor adds nothing to the mechanics of the game, but wait for behaviours to tell other behaviours - that "Subscribe" to these Events - about their occurance.
These "Subscribers" get to know when these events have occured and have hence already defined what code they want to execute then.

For everyone to be listening to game events, there needs to be some - ONE that they are listening to for said events. and that someone needs to be listening to ones who tell it when these events occur.


References:
Sebastian Lague's 2 part video explanation that destigmatised events and delegates for me:
https://www.youtube.com/watch?v=G5R4C8BLEOc
