using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    #region Data Types
    #region  Basic Data Types
    // Basic Data Types
    public float oneFloat;
    public Vector2 v2;
    public Vector3 v3;
    #endregion
    #region Struct Data Types
    // Struct Data Types
    [System.Serializable]
    public struct ExampleStruct
    {
        public string name;
        public bool lightSwitch;
        public Vector3 position;
        public GameObject objectReference;
    }
    public ExampleStruct exampleStruct;
    //ARRAY = [] = This is a collection of the same type of data
    //in this case the collection of data is the struct container ExampleStruct
    public ExampleStruct[] arrayOfStructs;
    #endregion
    #region Component Data Types
    // Component Data Types
    public Transform transformComponent;
    // An enum is a comma seperated list of identifiers
    #endregion
    #endregion
    #region Operators and Braces
    #region Modifying Operators
    /*
     Modifying operators are used mostly on singular lines of code
     
        +       addition
        ++      increment by 1
        +=      shortcut to add two sums together
        -       subtract
        --      decrement by 1
        -=      shortcut to subtract two numbers
        *       multiply
        /       divide
        /=      shortcut to divide two numbers
        *=      shortcut to multiply two numbers
        
        !       modifiers only when used with bools
     */
    #endregion
    #region Conditional Operators
    /*
     Conditonal Operators help us see if a situation is being met

        ==      equals too
        ||      or (one or the other conditions being met)
        &&      and (both conditions being met)
        !       not
        !=      not equal too
        <       less than
        <=      less than or equals too
        >       greater than
        >=      greater than or equals too

     */
    #endregion
    #region Brackets and Braces
    /*
        ()      parenthesis
        Are typically used for method or delegate invocation or in cast expressions.
        You also use parenthesis to specify the order in which to evaluate operations in an expression
        []      square brackets
        Are used for array, indexer, or pointer element access
        {}      curly brackets
        Hold and group code
        <>      angle brackets
        Calls generic methods, script or component
    */
    #endregion
    #endregion
    #region Functions/behaviours
    #region Initialization Events
    /*
        It is often useful to be able to call initialization code 
        in advance of any updates that occur during gameplay
    */
    private void Awake()
    {
        //runs once the moment an object is acvtive in ths scene
        //useful for grabbing references
    }

    private void Start()
    {
        //runs once when the script is enabled in the scene before the first frame update
        //useful for initializing
    }

    private void OnEnable()
    {
        //happens the moment the component is enabled and the gameobject is already enabled
    }
    #endregion

    void Update()
    {
        
    }
    #endregion
}
