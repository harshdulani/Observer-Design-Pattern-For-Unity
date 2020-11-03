1. singleton class that declares and holds invokation functions for doorevents

2. door class that defines the behaviour of the event

3. trigger class that knows the situation when the events need to be called and hence calls them

breakdown:

1. event library/manager - stores the event declaration & invoke()
2. event listener - calls the event
3. event dispatcher - announces the event

summary:

for everyone to be listening to game events, there needs to be some - ONE that they are listening to for said events. and that someone needs to be listening to someone who tells it when these events occur.