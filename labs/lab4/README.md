### 3 types - [link](https://www.hackerearth.com/practice/algorithms/graphs/minimum-spanning-tree/practice-problems/algorithm/3-types/)

Let's consider some weird country with N cities and M bidirectional roads of 3 types. It's weird because of some unusual rules about using these roads: men can use roads of types 1 and 3 only and women can use roads of types 2 and 3 only. Please answer the following very interesting question: what is maximum number of roads it's possible to destroy that the country will be still connected for both men and women? Connected country is country where it's possible to travel from any city to any other using existing roads.

Input

The first line contains 2 space-separated integer: N and M. Each of the following M lines contain description of one edge: three different space-separated integers: a, b and c. a and b are different and from 1 to N each and denote numbers of vertices that are connected by this edge. c denotes type of this edge.

Output

For each test case output one integer - maximal number of roads it's possible to destroy or -1 if the country is not connected initially for both men and women.
