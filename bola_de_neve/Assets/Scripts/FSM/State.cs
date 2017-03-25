using System;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
	public abstract class State<F, S>
		where  F: FSM<F, S>
		where S: State<F, S>
	{
		protected F fsm{ get; private set; }
		string name;

		public State (F fsm)
		{
			this.fsm = fsm;
		}

		public virtual void OnEnter(){}

		public virtual void OnLeave(){}

		public virtual void Update(){}
	}
}
