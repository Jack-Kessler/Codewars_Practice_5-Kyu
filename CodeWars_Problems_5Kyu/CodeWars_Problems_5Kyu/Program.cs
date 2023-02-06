// Flotsam (5-Kyu) (Completed 2/5/2023 - 14th day since start of bootcamp)

//using System.Runtime.Intrinsics.X86;
//using NUnit.Framework;
//using System;
//using System.Linq;

//char[][] image =
//    {
//        new char[] {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','|','=','=','|',' ',' ','|','=','=','|',' ',' ','|','=','=','|',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
//        new char[] {' ',' ',' ',' ',' ',' ',' ',' ','_','_','|','_','_','|','_','_','|','_','_','|','_','_','|','_','_','|','_',' ',' ',' ',' ',' ',' ',' ',' ',' '},
//        new char[] {' ',' ',' ',' ',' ','_','_','|','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','|','_','_','_',' ',' ',' ',' ',' '},
//        new char[] {' ',' ','_','_','|','_','_','[',']','_','_','[',']','_','_','[',']','_','_','[',']','_','_','[',']','_','_','[',']','_','_','|','_','x','x','x'},
//        new char[] {'~','|',' ',' ',' ','F',' ',' ','x',' ',' ','S',' ',' ',' ',' ','x',' ',' ','T',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','/','~'},
//        new char[] {'~','|','_','_','_','_','_','_','|','_','_','_','_','_','_','_','|','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','_','/','~','~'},
//        new char[] {'~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~','~'}
//      };

//int i = 0;
//int j = 0;

//int f1 = 0;
//int f2 = 0;

//int s1 = 0;
//int s2 = 0;

//int t1 = 0;
//int t2 = 0;

//int[] xCoordHitArray = { 0 };
//int[] yCoordHitArray = { 0 };

//bool hitExists = false;

//string survivors = "";

//int seaLevel = 0;

//for (int q = 0; q < image.Length; q++) //check for sea level
//{
//    if (image[q][0] == '~')
//    {
//        seaLevel = q;
//        break;
//    }

//}

//for (i = 0; i < image.Length; i++)
//{
//    for (j = 0; j < image[i].Length; j++)
//    {
//        if (image[i][j] == 'F') //find coordinates of Frank
//        {
//            f1 = i;
//            f2 = j;
//        }
//        else if (image[i][j] == 'S') //Find coordniates of Sam
//        {
//            s1 = i;
//            s2 = j;
//        }
//        else if (image[i][j] == 'T') //Find coordinates of Tom
//        {
//            t1 = i;
//            t2 = j;
//        }
//        else if (image[i][j] == 'x') //Find coordinates of each hit
//        {
//             if (i < seaLevel) //Sea level case. Hit is voided.
//            {
//                image[i][j] = 'D';
//            }
//            else if (image[i + 1][j] != '~' && image[i - 1][j] != '~' && image[i][j + 1] != '~' && image[i][j - 1] != '~')
//                //Voiding hits that do not touch water (as per instructions)
//            {
//                image[i][j] = ' ';
//            }
//            else if (image[i + 1][j] == '~' || image[i - 1][j] == '~'|| image[i][j + 1] == '~' || image[i][j - 1] == '~' )
//            {
//                yCoordHitArray = yCoordHitArray.Append(i).ToArray(); //adds y coordinate of hit touching water. LINQ Append() Method: https://code-maze.com/add-values-to-csharp-array/
//                xCoordHitArray = xCoordHitArray.Append(j).ToArray(); //adds x coordinate of hit touching water
//                hitExists = true;
//            }
//        }
//    }

//}

//xCoordHitArray = xCoordHitArray.Skip(1).ToArray(); //removes initial 0 entry at index 0.
//yCoordHitArray = yCoordHitArray.Skip(1).ToArray(); //removes initial 0 entry at index 0.

//i = 0; //reset counter i to zero for loop below
//j = 0; //reset counter j to zero for loop below

//image[f1][f2] = ' '; //Setting Frank position to blank. Since we already have coordinates, does not need to remain there.
//image[s1][s2] = ' '; //Setting Frank position to blank.
//image[t1][t2] = ' '; //Setting Frank position to blank.


//if (hitExists == false)
//{
//    survivors = "";
//}
//else
//{
//    for (i = 0; i < xCoordHitArray.Length; i++)
//    {
//        //Check if coordinate below hit is blank space
//        if (image[yCoordHitArray[i] + 1][xCoordHitArray[j]] == ' ')
//        {
//            image[yCoordHitArray[i] + 1][xCoordHitArray[j]] = '~';
//            yCoordHitArray = yCoordHitArray.Append(yCoordHitArray[i] + 1).ToArray();
//            xCoordHitArray = xCoordHitArray.Append(xCoordHitArray[j]).ToArray();
//            i--;
//        }
//        //check if coordinate above hit is blank space
//        else if (image[yCoordHitArray[i] - 1][xCoordHitArray[j]] == ' ')
//        {
//            image[yCoordHitArray[i] - 1][xCoordHitArray[j]] = '~';
//            yCoordHitArray = yCoordHitArray.Append(yCoordHitArray[i] - 1).ToArray();
//            xCoordHitArray = xCoordHitArray.Append(xCoordHitArray[j]).ToArray();
//            i--;
//        }
//        //check if coordinate to the right of the hit is blank space
//        else if (image[yCoordHitArray[i]][xCoordHitArray[j] + 1] == ' ')
//        {
//            image[yCoordHitArray[i]][xCoordHitArray[j] + 1] = '~';
//            yCoordHitArray = yCoordHitArray.Append(yCoordHitArray[i]).ToArray();
//            xCoordHitArray = xCoordHitArray.Append(xCoordHitArray[j] + 1).ToArray();
//            i--;
//        }
//        //check if coordinate to the left of the hit is blank space
//        else if (image[yCoordHitArray[i]][xCoordHitArray[j] - 1] == ' ')
//        {
//            image[yCoordHitArray[i]][xCoordHitArray[j] - 1] = '~';
//            yCoordHitArray = yCoordHitArray.Append(yCoordHitArray[i]).ToArray();
//            xCoordHitArray = xCoordHitArray.Append(xCoordHitArray[j] - 1).ToArray();
//            i--;
//        }
//        else
//        {
//            j++;
//        }
//    }
//}

//// At this point, we have filled out all areas where water can leak in from hits that were originally touching water

//bool frankSurvived = true;
//bool samSurvived = true;
//bool tomSurvived = true;

//for (i = 0; i < yCoordHitArray.Length; i++)
//{
//    if (f1 == yCoordHitArray[i] && f2 == xCoordHitArray[i]) //check if location of Frank was now under water
//    {
//        frankSurvived = false; ;
//    }
//    else if (s1 == yCoordHitArray[i] && s2 == xCoordHitArray[i]) //check if location of Sam was now under water
//    {
//        samSurvived = false;
//    }
//    else if (t1 == yCoordHitArray[i] && t2 == xCoordHitArray[i]) //check if location of Tom was now under water
//    {
//        tomSurvived = false;
//    }

//}

//if (frankSurvived == true)
//{
//    survivors += "Frank";
//}
//if (samSurvived == true)
//{
//    if (survivors == "")
//    {
//        survivors = "Sam";
//    }
//    else
//    {
//        survivors += " Sam";
//    }
//}
//if (tomSurvived == true)
//{
//    if (survivors == "")
//    {
//        survivors = "Tom";
//    }
//    else
//    {
//        survivors += " Tom";
//    }
//}

//Console.WriteLine(survivors);
//return survivors;


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

// ROT13 (5-Kyu) (Completed 2/5/2023 - 14th day since start of bootcamp)
//
//string sample = "EBG13 rknzcyr.";
//int charNumber = 0;

//char[] charArray = sample.ToCharArray();
//char[] resultArray = new char[sample.Length];

//for (int i = 0;i < charArray.Length; i++)
//{
//    charNumber = (int)charArray[i]; //initilaizes number associated with letter at charArray[i]
//                                    //(Note it does not matter what number letters actually are)
//    if (charNumber >= 'a' && charNumber <= 'm')
//    {
//        charNumber += 13;
//        resultArray[i] = (char)charNumber;
//    }
//    else if (charNumber >= 'n' && charNumber <= 'z')
//    {
//        charNumber -= 13;
//        resultArray[i] = (char)charNumber;
//    }
//    else if (charNumber >= 'A' && charNumber <= 'M')
//    {
//        charNumber += 13;
//        resultArray[i] = (char)charNumber;
//    }
//    else if (charNumber >= 'N' && charNumber <= 'Z')
//    {
//        charNumber -= 13;
//        resultArray[i] = (char)charNumber;
//    }
//    else
//    {
//        resultArray[i] = (char)charNumber;
//    }
//}

//string result = new string(resultArray);

//Console.WriteLine(result);


//return result;

//-----------------------------------------------------------------------------------------------------------------------------