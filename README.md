# Coffee


A certain company has attempted to motivate its employees by prioritizing access to coffee. Each employee has been given a priority from 0.0 to 100.0 based on their productivity over the last year, where 100.0 means that someone was extremely productive and 0.0 means that they did nothing at all. More productive employees (i.e. those with higher numbers) get coffee first.

A room that can hold up to N people contains a coffee machine with an infinite supply of coffee. There is a line of employees waiting to enter the room, and as soon as there is any free space in the room, employees will immediately enter until the room is full again. When the coffee machine has brewed a coffee, the employee with the highest priority receives it and leaves the room (only to be immediately replaced by a newly arriving one).

The program should help the employees quickly determine who in the room has the highest priority at any given moment, so there will be no battles over coffee. The first input line will contain the room capacity N. Each line after that contains an employee's name (a single word delimited by whitespace) and their priority (a floating-point number). Employees are listed in the order in which they will enter the room.

When the room is full, the program should output the name and priority of the highest-priority employee who is present, who receives a mug of coffee and leaves. When there are no more employees to arrive, the program should output the names and priorities of the remaining employees in descending order and terminate.


## Usage example: 

**Sample input:**

- 3
- andrew 10.0
- anna 30.0
- ashley 15.0
- benjamin 20.0
- caleb 25.0

**Output:**

- anna 30.0
- benjamin 20.0
- caleb 25.0
- ashley 15.0
- andrew 10.0

**Sample input #2:**

- 5
- ales 87
- alois 94
- alzbeta 41
- andrea 20
- bara 38
- berta 77
- blanka 17
- daniela 35
- denisa 11
- filip 72

**Output:**

- alois 94.0
- ales 87.0
- berta 77.0
- alzbeta 41.0
- bara 38.0
- filip 72.0
- daniela 35.0
- andrea 20.0
- blanka 17.0
- denisa 11.0


**Sample input #3:**

- 10
- ales 99
- alois 9
- alzbeta 32
- andrea 58
- bara 78
- berta 75
- blanka 56
- daniela 13
- denisa 24
- filip 6
- gabriela 29
- hana 21
- hedvika 91
- honza 61
- hubert 2
- hynek 25
- irena 89
- iveta 37
- jakub 72
- jiri 5

**Output:**

- ales 99.0
- bara 78.0
- berta 75.0
- hedvika 91.0
- honza 61.0
- andrea 58.0
- blanka 56.0
- irena 89.0
- iveta 37.0
- jakub 72.0
- alzbeta 32.0
- gabriela 29.0
- hynek 25.0
- denisa 24.0
- hana 21.0
- daniela 13.0
- alois 9.0
- filip 6.0
- jiri 5.0
- hubert 2.0
