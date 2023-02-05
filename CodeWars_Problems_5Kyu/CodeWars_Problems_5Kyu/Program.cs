// Flotsam (5-Kyu) (Completed 2/5/2023 - 14th day since start of bootcamp)

using System.Runtime.Intrinsics.X86;

char[][] image =
    {
        new char[] {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','=','=','|',' ',' ','|','=','=','|',' ',' ','|','=','=','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
        new char[] {' ',' ',' ',' ',' ',' ',' ',' ','_','_','|','_','_','|','_','_','|','_','_','|','_','_','|','_','_','|','_',' ',' ',' ',' ',' ',' ',' ',' ',' '},
        new char[] {' ',' ',' ',' ',' ','_','_','|','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','|','_','_','_',' ',' ',' ',' ',' '},
        new char[] {' ',' ','_','_','|','_','_','[',']','_','_','[',']','_','_','[',']','_','_','[',']','_','_','[',']','_','_','[',']','_','_','|','_','x','x','x'},
        new char[] {'~','|',' ',' ',' ','F',' ',' ','x',' ',' ','S',' ',' ',' ',' ','x',' ',' ','T',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','/','~'},
        new char[] {'~','|','_','_','_','_','_','_','|','_','_','_','_','_','_','_','|','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','/','~','~'},
        new char[] {'~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~'}
      };

int i = 0;
int j = 0;

int f1 = 0;
int f2 = 0;

int s1 = 0;
int s2 = 0;

int t1 = 0;
int t2 = 0;

int[] xCoordHitTop = { 0 };
int[] yCoordHitTop = { 0 };

int[] xCoordHitBottom = { 0 };
int[] yCoordHitBottom = { 0 };

int[] xCoordHitRight = { 0 };
int[] yCoordHitRight = { 0 };

int[] xCoordHitLeft = { 0 };
int[] yCoordHitLeft = { 0 };

bool hitExists = false;

string survivors = "";
int xHitCounter = 0;
bool breakLoop = false;

for (i = 0; i < image.Length; i++)
{
    for (j = 0; j < image[i].Length; j++)
    {
        if (image[i][j] == 'F') //find coordinates of Frank
        {
            f1 = i;
            f2 = j;
        }
        else if (image[i][j] == 'S') //Find coordniates of Sam
        {
            s1 = i;
            s2 = j;
        }
        else if (image[i][j] == 'T') //Find coordinates of Tom
        {
            t1 = i;
            t2 = j;
        }
        else if (image[i][j] == 'x') //Find coordinates of each hit
        {
            if (image[i + 1][j] != '~' && image[i - 1][j] != '~' && image[i][j + 1] != '~' && image[i][j - 1] != '~')
                //Voiding hits that do not touch water (as per instructions)
            {
                image[i][j] = ' ';
            }
            else if (image[i + 1][j] == '~')
            //Finding coordinates of hits touching water on the top (i.e. Submarine case. Water would come down)
            {
                yCoordHitTop = yCoordHitTop.Append(i).ToArray(); //tells us which row we are looking at (y-axis)
                
                //LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/

                xCoordHitTop = xCoordHitTop.Append(j).ToArray(); //tells us which column (position within a subarray) we are looking at (x axis)
                hitExists = true;
                xHitCounter++;
                //code above puts all hit coordinates touching water above in two arrarys.
                //One for x coordinates (column) and one for y coordinates (row).
            }
            else if (image[i - 1][j] == '~')
            //Finding coordinates of hits touching water below.
            {
                yCoordHitBottom = yCoordHitBottom.Append(i).ToArray(); //tells us which row we are looking at (y-axis)

                //LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/

                xCoordHitBottom = xCoordHitBottom.Append(j).ToArray(); //tells us which column (position within a subarray) we are looking at (x axis)
                hitExists = true;
                xHitCounter++;
                //code above puts all hit coordinates touching water below in two arrarys.
                //One for x coordinates (column) and one for y coordinates (row).
            }
            else if (image[i][j + 1] == '~')
            //Finding coordinates of hits touching water to the right.
            {
                yCoordHitRight = yCoordHitRight.Append(i).ToArray(); //tells us which row we are looking at (y-axis)

                //LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/

                xCoordHitRight = xCoordHitRight.Append(j).ToArray(); //tells us which column (position within a subarray) we are looking at (x axis)
                hitExists = true;
                xHitCounter++;
                //code above puts all hit coordinates touching water to the right in two arrarys.
                //One for x coordinates (column) and one for y coordinates (row).
            }
            else if (image[i][j - 1] == '~')
            //Finding coordinates of hits touching water to the left.
            {
                yCoordHitLeft = yCoordHitLeft.Append(i).ToArray(); //tells us which row we are looking at (y-axis)

                //LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/

                xCoordHitLeft = xCoordHitLeft.Append(j).ToArray(); //tells us which column (position within a subarray) we are looking at (x axis)
                hitExists = true;
                xHitCounter++;
                //code above puts all hit coordinates touching water to the left in two arrarys.
                //One for x coordinates (column) and one for y coordinates (row).
            }
        }
    }

}

xCoordHitTop = xCoordHitTop.Skip(1).ToArray(); //remove initial 0 entry at index 0. Note: last index now becomes 0. 
yCoordHitTop = yCoordHitTop.Skip(1).ToArray(); //remove initial 0 entry at index 0. Note: last index now becomes 0.

xCoordHitBottom = xCoordHitBottom.Skip(1).ToArray();
yCoordHitBottom = yCoordHitBottom.Skip(1).ToArray() ;

xCoordHitRight = xCoordHitRight.Skip(1).ToArray();
yCoordHitRight = yCoordHitRight.Skip(1).ToArray();

xCoordHitLeft = xCoordHitLeft.Skip(1).ToArray();
yCoordHitLeft = yCoordHitLeft.Skip(1).ToArray();



i = 0; //reset counter i to zero for loop below
j = 0; //reset counter j to zero for loop below
int k = 1;

if (hitExists == false)
{
    survivors = "";
}
else
{   
        for (i = 0; i < yCoordHitTop.Length; i++)
        // First, stretch hits starting at the top in the downward direction (i.e. case of submarine)
        // +k because of inversion. remember, bottom of array = largest index
        {
            if (image[yCoordHitTop[i] + k][xCoordHitTop[i]] == ' ') //looking at index k spaces beneath original hit
            {
                image[yCoordHitTop[i] + k][xCoordHitTop[i]] = 'x';
                i = -1;
                k++;
            }
            else
            {
                k = 1;
            }
        }

        for (i = 0; i < yCoordHitBottom.Length; i++)
        // Next, stretch hits starting at the bottom in the upward direction
        {
            if (image[yCoordHitBottom[i] - k][xCoordHitBottom[i]] == ' ') //looking at index k spaces above original hit
            {
                image[yCoordHitBottom[i] - k][xCoordHitBottom[i]] = 'x';
                i = -1;
                k++;
            }
            else
            {
                k = 1;
            }
        }

        for (i = 0; i < xCoordHitLeft.Length; i++)
        // Next, stretch hits starting at the left to the right
        {
            if (image[yCoordHitLeft[i]][xCoordHitLeft[j] + k] == ' ') //looking at index k spaces to the right of original hit
        {
                image[yCoordHitLeft[i]][xCoordHitLeft[j] + k] = 'x';
                i = -1;
                k++;
            }
            else
            {
                k = 1;
            }
        }

        for (i = 0; i < xCoordHitRight.Length; i++)
        // Next, stretch hits starting at the right to the left
        {
            if (image[yCoordHitRight[i]][xCoordHitRight[j] - k] == ' ') //looking at index k spaces to the left of original hit
        {
                image[yCoordHitRight[i]][xCoordHitRight[j] - k] = 'x';
                i = -1;
                k++;
            }
            else
            {
                k = 1;
            }
        }

    // To this point, we have identified the coordinates of Frank, Sam, and Tom...
    // and we have identified at stretched hits that initially touched water.
    // Now, we have to see if water (coming through the hits) will ever reach Frank, Sam, or Tom.

    //Frank         **Still need to exclude if they run into eachother

    int[] tempFrankY = { f1 };
    int[] tempFrankX = { f2 };
    

    //yCoordHitTop = yCoordHitTop.Append(i).ToArray(); //tells us which row we are looking at (y-axis)
    //CoordHitTop = xCoordHitTop.Append(j).ToArray(); //tells us which column (position within a subarray) we are looking at (x axis)

    image[s1][s2] = ' '; //temporarily making Sam location space. Will fix back later.
    image[t1][t2] = ' '; //temporarily making Tom location space. Will fix back later.

    k = 1;

    for (i = 0; i < tempFrankX.Length; i++)
    {
        if (tempFrankX[i] + k < image[f1].Length && image[tempFrankY[i]][tempFrankX[i]+k] == ' ') 
           //making sure array is in-bounds and replacing space to right of Frank with 'F'
        {
            image[tempFrankY[i]][tempFrankX[i] + k] = 'F';
            tempFrankY = tempFrankY.Append(f1).ToArray(); //recording new Y coordinate that must be re-evaluated for spaces next to
            tempFrankX = tempFrankX.Append(f2 + k).ToArray(); //recording new X coordinate that must be re-evaluated for spaces next to
            i = -1;
            k++;
        }
        else if (tempFrankX[i] - k >= 0 && image[tempFrankY[i]][tempFrankX[i] - k] == ' ')
            //making sure array is in-bounds and replacing space to left of Frank with 'F'
        {
            image[tempFrankY[i]][tempFrankX[i] - k] = 'F';
            tempFrankY = tempFrankY.Append(f1).ToArray(); //recording new Y coordinate that must be re-evaluated for spaces next to
            tempFrankX = tempFrankX.Append(f2 - k).ToArray(); //recording new X coordinate that must be re-evaluated for spaces next to
            i = -1;
            k++;
        }
        else if (tempFrankY[i] + k < image.Length && image[tempFrankY[i] + k][tempFrankX[i]] == ' ')
            //making sure array is in-bounds and replacing space below Frank with 'F'
        {
            image[tempFrankX[i] + 1][tempFrankY[i]] = 'F';
            tempFrankX = tempFrankX.Append(f1 + k).ToArray(); //recording new X coordinate that must be re-evaluated for spaces next to
            tempFrankY = tempFrankY.Append(f2).ToArray(); //recording new Y coordinate that must be re-evaluated for spaces next to
            i = -1;
            k++;
        }
        else if (tempFrankY[i] - k < image.Length && image[tempFrankY[i] - k][tempFrankX[i]] == ' ') 
            //making sure array is in-bounds and replacing space above Frank with 'F'
        {
            image[tempFrankX[i] - k][tempFrankY[i]] = 'F';
            tempFrankX = tempFrankX.Append(f1 - k).ToArray(); //recording new X coordinate that must be re-evaluated for spaces next to
            tempFrankY = tempFrankY.Append(f2).ToArray(); //recording new Y coordinate that must be re-evaluated for spaces next to
            i = -1;
            k++;
        }
    }

    //Add code for if F is next to 'X', then Frank is dead

    //Now do the same with Sam and Tom


    //while (breakLoop == false)
    //{
    //    if (up + 1 < image.Length && image[up + 1][f2] == 'x' || // making sure array is in-bounds. If x is next to up, dn, right, or left...
    //        dn - 1 >= 0 && image[dn - 1][f2] == 'x' ||           // water has reached Frank.
    //        right + 1 < image[f1].Length && image[f1][right + 1] == 'x' ||
    //        left - 1 >= 0 && image[f1][left - 1] == 'x')
    //    {
    //        survivors = "";
    //        breakLoop = true;
    //    }
    //    else if (up + 1 < image.Length && image[up + 1][f2] == ' ') //making sure array is in-bounds and replacing space with 'x'
    //    {
    //        tempFrankX = tempFrankX.Append(up + 1).ToArray();
    //        up++;
    //    }
    //    else if (dn - 1 >= 0 && image[dn - 1][f2] == ' ') //making sure array is in-bounds and replacing space with 'x'
    //    {
    //        dn--;
    //    }
    //    else if (right + 1 < image[f1].Length && image[f1][right + 1] == ' ') //making sure array is in-bounds and replacing space with 'x'
    //    {
    //        right++;
    //    }
    //    else if (left - 1 >= 0 && image[f1][left - 1] == ' ') //making sure array is in-bounds and replacing space with 'x'
    //    {
    //        left--;
    //    }
    //    else
    //    {
    //        survivors = survivors + "Frank";
    //        breakLoop = true;
    //    }
    //}
}


//{
//    while (i < xHitCounter)
//    {
//        if (xCoordArray[i] + 1 <= image.Length && image[xCoordArray[i] + 1][j] == ' ')
//        {
//            image[xCoordArray[i] + 1][j] = 'x';
//        }
//        else if (xCoordArray[i] - 1 >= 0 && image[xCoordArray[i] - 1][j] == ' ')
//        {
//            image[xCoordArray[i] + 1][j] = 'x';
//        }
//        else if (yCoordArray[i] + 1 <= image[yCoordArray[i]].Length && image[i][yCoordArray[i] + 1] == ' ')
//        {
//            image[i][yCoordArray[i] + 1] = ' ';
//        }
//        else if (yCoordArray[i] - 1 >= 0 && image[i][yCoordArray[i] - 1] == ' ')
//        {
//            image[i][yCoordArray[i] - 1] = ' ';
//        }
//        else

//        i++;
//    }
//}


//-----------------------------------------------------------------------------------------------------------------------------


//Hofstadter 's Figure-Figure Sequence (5-Kyu) (Completed 2/4/2023 - 13th day since start of bootcamp)

// **** Code below works but it is ineffcient and timed out on Codewars ****
//using NUnit.Framework;
//using System;
//using System.Linq;

//int n = 10;
//int[] aArray = { 1, 3 };
//int[] bArray = { 2, 4 };

//int aCounter = 2;
//int bCounter = 1;
//int tempAVal = 0;
//int tempBVal = 0;
//int answer = 0;

//if (n < 0 || n > 1000000) //check to make sure n is between 0 and 1,000,000 per instructions
//{
//    answer = -1;
//}
//else
//{
//    while (aCounter <= n)
//    {
//        tempAVal = aArray[aCounter -1] + bArray[aCounter - 1];
//        aArray = aArray.Append(tempAVal).ToArray();             //LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/
//        tempBVal = bArray[bCounter] + 1;
//        while (tempBVal < aArray[aCounter])
//        {
//            if (tempBVal == aArray[aCounter - 1])
//            {
//                tempBVal++;
//            }
//            else
//            {
//                bArray = bArray.Append(tempBVal).ToArray();             //LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/
//                bCounter++;
//                tempBVal = bArray[bCounter] + 1;
//            }

//        }
//        aCounter++;
//    }
//}

//if (answer == -1)
//{
//    Console.WriteLine("Error");
//    //return answer
//}
//else
//{
//    Console.WriteLine(aArray[n]);
//    //return aArray[n];
//}

// **** Code below is optimzed ****

//using NUnit.Framework;
//using System;
//using System.Linq;

//int n = 10;

//int[] aArray = new int[n + 2]; //This method only fills out absolutely necessary indexes of each array
//int[] bArray = new int[n + 2]; //The original method made for a very large bArray.

//aArray[0] = 1;
//bArray[0] = 2;
//aArray[1] = 3;
//bArray[1] = 4;

//int aCounter = 2; // the current index of array aArray
//int bCheckCounter = 2; // the index in aArray that should be compared against to make sure bArray does not have any numbers already in aArray
//int answer = 0; //needed since codewars required a int to be returned. Used for error case only.

//if (n < 0 || n > 1000000) //check to make sure n is between 0 and 1,000,000 per instructions
//{
//    answer = -1;
//}
//else
//{
//    while (aCounter <= n) //make sure we are replacing zeros in both arrays until index reaches n
//    {
//        aArray[aCounter] = aArray[aCounter - 1] + bArray[aCounter - 1]; // replacing 0 with correct number in aArray at index aCounter

//        if (bArray[aCounter - 1] + 1 != aArray[bCheckCounter]) 
//            //Making sure value at (index aCounter -1) of bArray does not equal value in aArray at index (bCheckCounter).
//            //Again, dont want duplicates.
//        {
//            bArray[aCounter] = bArray[aCounter - 1] + 1;
//        }
//        else //Case where value at (index aCounter -1) of bArray does equal value in aArray at index (bCheckCounter).
//             //To avoid duplicating, we add 2 (instead of 1) to the last non-zero bArray value (found at index aCounter - 1).
//        {
//            bArray[aCounter] = bArray[aCounter - 1] + 2;
//            bCheckCounter++; //Note: we need to move our bCheckCounter up one...
//                             //so that we can check any new bArray additions moving forward against the next potential duplicate conflicts
//                             //with aArray at position (bCheckCounter++).
//        }
//        aCounter++; //Lastly, we need to move our (aCounter) up one so that we overwrite the next zero in aArray. If we didn't do this step
//                    //we would attempt to overwrite the index that we changed just above. 
//    }
//}

//if (answer == -1)
//{
//    Console.WriteLine("Error");
//    //return answer
//}
//else
//{
//    Console.WriteLine(aArray[n]);
//    //return aArray[n];
//}
//-----------------------------------------------------------------------------------------------------------------------------
