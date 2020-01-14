using Com.Github.Knose1.InputUtils.Utils;
using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Com.Github.Knose1.InputUtils.InputController {

	//This is an example of a fully parameterized Controller.cs
	public partial class Controller
	{
		private UnityInputSystem input;
		public UnityInputSystem Input { get => input; }
		
		partial void InitControllerProject()
		{
			input = new UnityInputSystem();
		}

		partial void GetRebindingFunctionsEditor()
		{
			rebindingFunctionsEditor = new List<RebindingFunction>();
			rebindingFunctionsEditor.Add(new RebindingFunction(RebindLeft, nameof(RebindLeft), ""));
			rebindingFunctionsEditor.Add(new RebindingFunction(RebindRight, nameof(RebindRight), ""));
		}
		partial void GetRebindingFunctions()
		{
			rebindingFunctions = new List<RebindingFunction>();
			rebindingFunctions.Add(new RebindingFunction(RebindLeft, nameof(RebindLeft), InputSystemUtils.GetName(input.Gameplay.Left)));
			rebindingFunctions.Add(new RebindingFunction(RebindRight, nameof(RebindRight), InputSystemUtils.GetName(input.Gameplay.Right)));
		}
		
		public void RebindLeft()
		{
			Rebind(input.Gameplay.Left, new List<InputAction>() { input.Gameplay.Right }).Start();
		}
		
		public void RebindRight()
		{
			Rebind(input.Gameplay.Right, new List<InputAction>() { input.Gameplay.Left }).Start();
		}
		public void OnDestroy()
		{
			DisposeInstance();
			
			input.Disable(); 
		}
	}
}
