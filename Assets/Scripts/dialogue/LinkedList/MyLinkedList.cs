using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyLinkedList<T>
{ //Node that will 'point' to the current node we are looking at
    public MyNode<T> Current
    {
        get;
        set;
    }

    //Node that will 'point' to the beginning of the linked list
    public MyNode<T> Head
    {
        get;
        set;
    }

    //Node that will 'point' to the last node in the linked list
    public MyNode<T> Tail
    {
        get;
        set;
    }

    public int Length = 0;

    //Constructor. Just initialize the properties to null
    public MyLinkedList()
    {
        Head = null;
        Tail = null;
        Current = null;
    }

    //This will be the add method to add a new node to the linked list
    public void Add(T content)
    {
        //Make a new node
        MyNode<T> node = new MyNode<T>();

        //Set the data for the node to the content that was passed in.
        node.Data = content;
        Length++;

        //If Head is null, that means that there are no nodes in the linked list
        if (Head == null)
        {
            Head = node;
            //This next line got moved below the if/else, so it is no longer needed
            //Tail = node;
        }
        //This is the case where there is already at least 1 node in the linked list. Maybe many.
        else
        {
            //Take the Tail Node, which is the last one in the list, and set it's Next property
            //which was null, to the new node we just created.
            Tail.Next = node;

            //This is a valid replacement for Tail = nde; but might be harder to understand.
            //Tail = Tail.Next;
            //This next line got moved below the if/else
            //Tail = node;
        }
        //This was replaced in both the if and the else, so we moved it down here since it must be
        //done for both of them.
        Tail = node;
    }

    public (int, string, string) FindLine(MyLinkedList<dialogueData> list, int LineID)
    {
        MyNode<dialogueData> tempNode = list.Head;
        MyNode<dialogueData> returnNode = null;

        dialogueData tempData = new dialogueData();

        while (tempNode != null)
        {
            if(tempNode.Data.lineID == LineID)
            {
                returnNode = tempNode;
                break;
            }
            //all needed working must be done before tempNode = tempNode.Next
            //goes to next element
            tempNode = tempNode.Next;
        }

        return (returnNode.Data.lineID, returnNode.Data.characterLine, returnNode.Data.characterNickname);
    }



    public T Retrive(int position)
    {
        //Used as a temporary pointer to a spot within the linked list
        MyNode<T> tempNode = Head;

        //Used to hold the node at the index indicated by the passed in position
        MyNode<T> returnNode = null;

        //Counter to see where we are in the list
        int count = 0;

        //While our tempNode is not at the end of the list
        while (tempNode != null)
        {
            //If the count and the position match. This means that it will be
            //zero based. If we want it to be 1 based, we would need to subtract
            //1 from the position.
            if (count == position)
            {
                //Set the returnNode var to the tempNode, which is the one we were looking for
                returnNode = tempNode;
            }

            //Increment the count so that we actually move through the list
            count++;
            //Set the tempNode to tempNode's next property, which will move us to the next
            //node in the linked list
            tempNode = tempNode.Next;
        }

        //We are going to use a ternary operator to do a smaller version of an if. I
        //This could easily be written as a if/ else.  Essentially the part in the ()
        //is the test, and the part between the ? and the : is what will happen if true.
        //The part after the : is what will happen when false.
        //The default(T) part is going to determine what the default value for
        //type T is, and then return that. Most of the time it eill probably
        //be null, but in case it isn't this will handle it. Putting just null
        //make the IDE complain, so we have to use this.
        return (returnNode != null) ? returnNode.Data : default(T);
    }
   

    public bool Delete(int position)
    {
        //return value for the method
        bool returnBool = false;

        //Set current to Head
        Current = Head;

        //If the position tha twe want to remove is the very first node, we need to do things
        //different tha if it is 1 thru the end.
        //This part is equivilent to always removing from the front. (hint hint)
        if (position == 0)
        {

            //Set the Head to the current.Next which will make Head point to the node
            //at index 1, instead of index 0.
            Head = Current.Next;

            //Set the Next Property of Current to nill so that the current
            //(which was the old Head) does not point to any other node.
            //This line is probably not 'required', but it does illustrate how
            //to clean up a node so it no linger points to anything
            Current.Next = null;

            //Set the current (which was the old Head) to null. Now that node no longer
            //exists, and can be garbage collected
            Current = null;
            //Check to see if the Head is null, if so, the Tail must become null as well
            //because it means we just deleted the last node in the list
            if (Head == null)
            {
                Tail = null;
            }


            //Set the return bool to true since the remove was successful
            returnBool = true;
        }
        else
        {
            //Set a tempNode to the first position in the linked list
            MyNode<T> tempNode = Head;
            //Declare a previous temp that will get a value after the tempNode moves
            MyNode<T> previousTempNode = null;
            //Start a counter to use to move through the linked list
            int count = 0;

            //Loop until the tmpNode is null, which means we are at the end
            while (tempNode != null)
            {
                //If we match the position and the count we are on, we found the 
                //one we need to delete
                if (count == position)
                {
                    //Set the previous nodes next to the tempNode's next
                    //jumping over the tempNode. The previous node's next will now
                    //point to the node AFTER the tempNode.
                    previousTempNode.Next = tempNode.Next;

                    //Check to see if we are deleting the very last node in the list
                    //if so we need to move the Tail pointer.
                    if (tempNode.Next == null)
                    {
                        //Set Tail to the previousTempNode, which is the new end of the list
                        Tail = previousTempNode;
                    }

                    //We found one to delete, so set the return bool to true.
                    returnBool = true;
                }

                //Increment the count so we move through the linked list.
                count++;

                //Set the previous tempNode to the current tempNode. This way when we
                //move the tempNode forward, we will still have a pointer to where 
                //the tempNode was before it moved.
                previousTempNode = tempNode;

                //Set the tempNode to tempNode's next property, which will move it down
                //the linked list one position.
                tempNode = tempNode.Next;
            }
        }

        return returnBool;
    }

    public void AddToFront(T content)
    {
        //Just make another pointer that points to the first node in the linked list
        MyNode<T> oldFirst = Head;
        //Overwrite head with a new Generic Node
        Head = new MyNode<T>();
        //Set the data on the node
        Head.Data = content;
        //Make Head's Next point to the old First
        Head.Next = oldFirst;
    }

    public T RemoveFromFront()
    {
        //Make a return node and set it to the Head, which is the first node in the
        //linked list
        MyNode<T> returnNode = Head;
        Head = Head.Next;
        //Check to see if Head is null, if so, set Tail to null as well. List is empty
        if (Head == null)
        {
            Tail = null;
        }
        //return the Data
        return returnNode.Data;
    }

    
} 
