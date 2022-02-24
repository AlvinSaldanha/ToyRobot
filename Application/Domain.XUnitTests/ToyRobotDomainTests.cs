using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Domain.XUnitTests
{
	public class ToyRobotDomainTests : ConfigureTestEnvironment
	{
		private readonly IToyRobotService _toyRobotService;

		public ToyRobotDomainTests()
		{
			_toyRobotService = Container.GetService<IToyRobotService>();
			_toyRobotService.ResetRobotState();
		}

		[Theory]
		[InlineData(0, 0, Direction.North, 5)]
		[InlineData(1, 2, Direction.East, 4)]
		[InlineData(2, 3, Direction.West, 2)]
		[InlineData(4, 5, Direction.South, 5)]
		public void Prevent_Robot_From_Falling_Off_The_Edge(int x, int y, Direction direction, int moveCountToEdge)
		{
			_toyRobotService.PlaceRobot(new PlaceCommandDto { X = x, Y = y, Direction = direction });
			for (int i = 0; i < moveCountToEdge - 1; i++)
			{
				_toyRobotService.ExecuteCommand(Command.Move);
			}

			var resultSuccess = _toyRobotService.ExecuteCommand(Command.Move);
			var resultError = _toyRobotService.ExecuteCommand(Command.Move);
			Assert.Equal(DomainOperationStatus.Success, resultSuccess.Status);
			Assert.Equal(DomainOperationStatus.Error, resultError.Status);
		}

		[Fact]
		public void Direction_Required_In_First_Place_Not_InSubsequent_Ones()
		{
			var resultFirstFailure = _toyRobotService.PlaceRobot(new PlaceCommandDto { X = 0, Y = 0 });
			Assert.Equal(DomainOperationStatus.Error, resultFirstFailure.Status);

			var resultFirstSuccess = _toyRobotService.PlaceRobot(new PlaceCommandDto { X = 0, Y = 0, Direction = Direction.North });
			Assert.Equal(DomainOperationStatus.Success, resultFirstSuccess.Status);

			var secondSuccessResult = _toyRobotService.PlaceRobot(new PlaceCommandDto { X = 0, Y = 0 });
			Assert.Equal(DomainOperationStatus.Success, secondSuccessResult.Status);
		}

		[Fact]
		public void First_Valid_Command_Should_Be_Place()
		{
			// Trying to execute Move, Left, Right and Report commands BEFORE executing Place should fail
			var resultMoveBeforePlace = _toyRobotService.ExecuteCommand(Command.Move);
			var resultLeftBeforePlace = _toyRobotService.ExecuteCommand(Command.Left);
			var resultRightBeforePlace = _toyRobotService.ExecuteCommand(Command.Right);
			var resultReportBeforePlace = _toyRobotService.ExecuteCommand(Command.Report);

			Assert.Equal(DomainOperationStatus.Error, resultMoveBeforePlace.Status);
			Assert.Equal(DomainOperationStatus.Error, resultLeftBeforePlace.Status);
			Assert.Equal(DomainOperationStatus.Error, resultRightBeforePlace.Status);
			Assert.Equal(DomainOperationStatus.Error, resultReportBeforePlace.Status);


			_toyRobotService.PlaceRobot(new PlaceCommandDto { X = 0, Y = 0, Direction = Direction.North });

			// Trying to execute Move, Left, Right and Report commands AFTER executing Place should succeed
			var resultMoveAfterPlace = _toyRobotService.ExecuteCommand(Command.Move);
			var resultLeftAfterPlace = _toyRobotService.ExecuteCommand(Command.Left);
			var resultRightAfterPlace = _toyRobotService.ExecuteCommand(Command.Right);
			var resultReportAfterPlace = _toyRobotService.ExecuteCommand(Command.Report);

			Assert.Equal(DomainOperationStatus.Success, resultMoveAfterPlace.Status);
			Assert.Equal(DomainOperationStatus.Success, resultLeftAfterPlace.Status);
			Assert.Equal(DomainOperationStatus.Success, resultRightAfterPlace.Status);
			Assert.Equal(DomainOperationStatus.Success, resultReportAfterPlace.Status);
		}

		[Theory]
		[InlineData(0, 0, Direction.North, "0,1,North", Command.Move )]
		[InlineData(0, 0, Direction.North, "0,0,West", Command.Left)]
		[InlineData(1, 2, Direction.East, "3,3,North", Command.Move,Command.Move,Command.Left,Command.Move)]
		[InlineData(1, 2, Direction.East, "4,4,East", Command.Move, Command.Move, Command.Left, Command.Move,Command.Move,Command.Right,Command.Move)]
		[InlineData(5, 5, Direction.South, "5,3,East", Command.Move, Command.Move, Command.Right, Command.Move, Command.Left, Command.Left, Command.Move)]
		public void Position_Should_Be_Reported_Correctly(int x, int y, Direction direction, string expectedOutput, params Command[] commands )
		{
			var resultFirstFailure = _toyRobotService.PlaceRobot(new PlaceCommandDto { X = x, Y = y, Direction = direction });
			foreach (var command in commands)
			{
				_toyRobotService.ExecuteCommand(command);
			}
			var result = _toyRobotService.ExecuteCommand(Command.Report);
			Assert.Equal(expectedOutput, $"{result.Value.X},{result.Value.Y},{result.Value.Direction}");
		}

		[Fact]
		public void Position_Should_Be_Reported_Correctly_With_Intermediate_DirectionLess_Place()
		{
			_toyRobotService.PlaceRobot(new PlaceCommandDto { X = 1, Y = 2, Direction = Direction.East });
			_toyRobotService.ExecuteCommand(Command.Move);
			_toyRobotService.ExecuteCommand(Command.Left);
			_toyRobotService.ExecuteCommand(Command.Move);
			_toyRobotService.PlaceRobot(new PlaceCommandDto { X = 3, Y = 1 });
			_toyRobotService.ExecuteCommand(Command.Move);
			var result = _toyRobotService.ExecuteCommand(Command.Report);
			Assert.Equal("3,2,North", $"{result.Value.X},{result.Value.Y},{result.Value.Direction}");
		}
	}
}
