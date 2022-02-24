

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace Domain.Tests
{
	[TestClass]
	public class ToyRobotDomainTests : ConfigureTestEnvironment
	{
		private readonly IToyRobotService _toyRobotService;

		public ToyRobotDomainTests()
		{
			_toyRobotService = Container.GetService<IToyRobotService>();
		}

		[Theory]
		[InlineData(0, 0, Direction.North, 5)]
		public void Prevent_Robot_From_Falling_Off_The_Edge(int x, int y, Direction direction, int moveCount)
		{
			_toyRobotService.PlaceRobot(new PlaceCommandDto { X = x, Y = y, Direction = direction });
			for (int i = 0; i < moveCount - 1; i++)
			{
				_toyRobotService.ExecuteCommand(Command.Move);
			}

			var resultSuccess = _toyRobotService.ExecuteCommand(Command.Move);
			var resultError = _toyRobotService.ExecuteCommand(Command.Move);
			Assert.AreEqual(DomainOperationStatus.Success, resultSuccess.Status);
			Assert.AreEqual(DomainOperationStatus.Error, resultError.Status);
		}

	}
}
