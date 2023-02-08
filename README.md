# SaatyAnalyticHierarchyProcess

This project was created as part of a class at Politechnika Częstochowska.

# Description:
The goal of this project was to create an application that represents Analytic Hierarchy Process (AHP) algorithm and allows user to help in their decision process.
Due to algorithm drawbacks the soultion was expanded upon by fuzzy sets.

# How it works:

Lets say you want to decide where to open your bank account. You are considering 3 banks: A,B and C but can't decide which one wold suit you the best. There are 5 things that are important to you when choosing one:
- number of bank outlets
- low interest rate
- card maintenance cost
- number of ATMs
- interest-free period

### Step 1:
Enter the amount of criteria and their criteria names

![image](https://user-images.githubusercontent.com/67912058/217528479-371eae02-dfd7-48aa-bd16-8dae2d54369f.png)

### Step 2:
Enter the even comparisons of criteria into a matrix. To do so compare the importance of criteria: is criteria Z more, less or equally as important as criteria X.
If there was a logical discrepancy the program will show an error message informing about wrong input.

![image](https://user-images.githubusercontent.com/67912058/217526123-31605378-60d2-41fd-b2eb-29190f264aad.png)

### Step 3:
For each criteria select the membership function (nummber from 1 to 7) that will best suit it

![image](https://user-images.githubusercontent.com/67912058/217527147-ed765bd1-522f-4469-a419-0dea84bc7d31.png)

### Step 4:
For each selected membership function input showcased keypoints

![image](https://user-images.githubusercontent.com/67912058/217527887-24054846-b4e8-4dc2-98a3-f37934b55458.png)


### Step 5:
Enter the amount of alternatives (banks) and their names, then input each banks data for each criteria ( bank A has 110 ATM's etc.)

![image](https://user-images.githubusercontent.com/67912058/217528693-38df2403-e656-42cf-8927-d3793966c81b.png)

### Step 6:
See the results:

- DD1: showcases lowest value of the results
- DD2: showcases the value multiplication  of the results
- DD3: showcases average value of the results

From the image below you can see that second bank would be the best despite having very poor performance for one of its criteria


![image](https://user-images.githubusercontent.com/67912058/217529234-0e7fa847-d189-44e4-aa9c-f696fb96a34b.png)



