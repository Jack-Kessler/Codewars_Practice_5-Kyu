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

int up = 0;
int dn = 0;
int right = 0;
int left = 0;

int[] xCoordArray = { 0 };
int[] yCoordArray = { 0 };

int tempxCoord = 0;
int tempyCoord = 0;
bool hitExists = false;

string survivors = "";
int xHitCounter = 0;
bool resetCounter = true;

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
            else if (image[i + 1][j] == '~' || image[i - 1][j] == '~' || image[i][j + 1] == '~' || image[i][j - 1] == '~')
            //Finding coordinates of hits touching water (up, dn, right, left).
            {
                yCoordArray = yCoordArray.Append(i).ToArray(); //tells us which row we are looking at (y-axis)
                
                //LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/

                xCoordArray = xCoordArray.Append(j).ToArray(); //tells us which column (position within a subarray) we are looking at (x axis)
                hitExists = true;
                xHitCounter++;
                //code above puts all hit coordinates touching water in two arrarys. One for x coordinates (column) and one for y coordinates (row).
            }
        }
    }

}

xCoordArray = xCoordArray.Skip(1).ToArray(); //remove initial 0 entry at index 0. Note: last index now becomes 0. 
yCoordArray = yCoordArray.Skip(1).ToArray(); //remove initial 0 entry at index 0. Note: last index now becomes 0.

i = 0; //reset counter i to zero for loop below
j = 0; //reset counter j to zero for loop below
int k = 1;

if (hitExists == false)
{
    survivors = "";
}
else
{   
    while (resetCounter == true)
    {
        for (i = 0; i < yCoordArray.Length; i++)
        // Need hits to stretch vertically where possible. Stretch from bottom to top first.
        // Code below is for water coming from bottom of the boat. Holes on the side will be taken care of later.
        {
            if (image[yCoordArray[i] + k][xCoordArray[j]] == ' ' && yCoordArray[i] + k < image.Length)
            {
                image[yCoordArray[i] + k][xCoordArray[j]] = 'x';
                i = 0;
                k++;
            }
            else
            {
                k = 1;
                j++;
            }
        }
        for (i = 0; i < yCoordArray.Length; i++)
        // Next, stretch from top to bottom (only in case of a submarine). Holes on the side will be taken care of later.
        {
            if (image[yCoordArray[i - k]][xCoordArray[j]] == ' ')
            {
                image[yCoordArray[i + k]][xCoordArray[j]] = 'x';
                i = 0;
                k++;
            }
            else
            {
                k = 1;
                j++;
            }
        }

        while (image[yCoordArray[i + 1]][xCoordArray[j]] == ' ' ||
               image[yCoordArray[i - 1]][xCoordArray[j]] == ' ')
        {
            if (image[yCoordArray[i + 1]][xCoordArray[j]] == ' ')
            {
                image[yCoordArray[i + 1]][xCoordArray[j]] = 'x';
                i++;
            }
            else if (image[yCoordArray[i - 1]][xCoordArray[j]] == ' ')
            {
                image[yCoordArray[i - 1]][xCoordArray[j]] = 'x';

            }
        }
    }
    while (resetCounter == true)
    {
        if (up + 1 <= image.Length && image[up + 1][f2] == 'x' || //making sure array is in-bounds and checking for x
            dn - 1 >= 0 && image[dn - 1][f2] == 'x' ||
            right + 1 <= image.Length && image[f1][right + 1] == 'x' ||
            left - 1 >= 0 && image[f1][left - 1] == 'x')
        {
            survivors = "";
            resetCounter = false;
        }
        else if (up + 1 <= image.Length && image[up + 1][f2] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            up = f1 + 1;
        }
        else if (dn - 1 >= 0 && image[dn - 1][f2] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            dn = f1 - 1;
        }
        else if (right + 1 <= image.Length && image[f1][right + 1] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            right = f2 + 1;
        }
        else if (left - 1 >= 0 && image[f1][left - 1] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            left = f2 - 1;
        }
        else
        {
            survivors = survivors + "Frank";
            resetCounter = false;
        }
    }


    //Frank **Still need to exclude if they run into eachother
    up = f1;
    dn = f1;
    right = f2;
    left = f2;
    while (resetCounter < 1)
    {
        if (up + 1 <= image.Length && image[up + 1][f2] == 'x' || //making sure array is in-bounds and checking for x
            dn - 1 >= 0 && image[dn - 1][f2] == 'x' ||
            right + 1 <= image.Length && image[f1][right + 1] == 'x' ||
            left - 1 >= 0 && image[f1][left - 1] == 'x')
        {
            survivors = "";
            resetCounter = 1;
        }
        else if (up + 1 <= image.Length && image[up + 1][f2] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            up = f1 + 1;
        }
        else if (dn - 1 >= 0 && image[dn - 1][f2] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            dn = f1 - 1;
        }
        else if (right + 1 <= image.Length && image[f1][right + 1] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            right = f2 + 1;
        }
        else if (left - 1 >= 0 && image[f1][left - 1] == ' ') //making sure array is in-bounds and replacing space with 'x'
        {
            left = f2 - 1;
        }
        else
        {
            survivors = survivors + "Frank";
            resetCounter = 1;
        }
    }
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
