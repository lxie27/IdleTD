using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class BaseModel {}
public class BaseController<M, V> 
	where M : BaseModel
	where V : BaseView<M>
{
	protected M Model;
	protected V View;

	public virtual void Setup(M model, V view)
	{
		Model = model;
		View = view;
	}
}

public class BaseView<M> : MonoBehaviour
	where M : BaseModel
{
	public M Model;

	public virtual void Awake(){}
}


