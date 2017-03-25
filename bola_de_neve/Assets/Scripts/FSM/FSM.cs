using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FSM
{
	public class FSM<F, S> 
		where  F: FSM<F, S>
		where S: State<F, S>{
		Stack<S> stateStack;
		bool started = false;
        

		public S Current
		{
			get{
				return stateStack.Peek ();
			}
		}

		public FSM()
		{
			stateStack = new Stack<S> ();
		}

		public void Push(S state)
		{
			if(stateStack.Count > 0)
				stateStack.Peek ().OnLeave ();
			stateStack.Push (state);
			state.OnEnter ();
		}

		public void Pop()
		{
			if (stateStack.Count > 0) {
				stateStack.Pop ().OnLeave ();
				stateStack.Peek ().OnEnter ();
			}
		}
		public void AdvanceTo(S state)
		{
			if(stateStack.Count > 0)
				stateStack.Pop ().OnLeave ();
			stateStack.Push (state);
			state.OnEnter ();
		}
	}
}
