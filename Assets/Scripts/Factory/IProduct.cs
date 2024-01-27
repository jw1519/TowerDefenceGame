using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public interface IProduct
    {
        //common properties of products
        public string ProductName { get; set; }

        public void Initialize();
    }

