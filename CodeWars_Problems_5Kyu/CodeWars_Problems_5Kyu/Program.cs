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
