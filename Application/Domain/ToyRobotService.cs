using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
	public class ToyRobotService : IToyRobotService
	{
		private static RobotState robotState;


		public DomainOperationResult<RobotState> PlaceRobot(PlaceCommandDto commandDto)
		{
			var result = ValidatePlaceCommand(commandDto);
			if (result.Status != DomainOperationStatus.Success)
				return result.ConvertTo<RobotState>();

			robotState = robotState == null ? new RobotState() : robotState;
			robotState.X = commandDto.X;
			robotState.Y = commandDto.Y;
			robotState.Direction = commandDto.Direction ?? robotState.Direction;
			return DomainOperationResult.Success(robotState);
		}


		public DomainOperationResult<RobotState> ExecuteCommand(Command command)
		{
			if (robotState == null)
				return DomainOperationResult.Error<RobotState>($"'Place' the robot before executing the '{command}' command");

			switch (command)
			{
				case Command.Move:
					return MoveRobot();
				case Command.Left:
				case Command.Right:
					robotState.Direction = GetDirection(command).Value;
					break;
				case Command.Report:
					break;
				default:
					break;
			}
			return DomainOperationResult.Success(robotState);
		}

		public void ResetRobotState()
		{
			robotState = null;
		}


		private DomainOperationResult<RobotState> MoveRobot()
		{
			var errorResult = DomainOperationResult.Error<RobotState>("Cannot execute 'Move' command as the Robot will fall off the tabletop");
			switch (robotState.Direction)
			{
				case Direction.North:
					if (robotState.Y == 5)
						return errorResult;
					robotState.Y++;
					break;
				case Direction.East:
					if (robotState.X == 5)
						return errorResult;
					robotState.X++;
					break;
				case Direction.South:
					if (robotState.Y == 0)
						return errorResult;
					robotState.Y--;
					break;
				case Direction.West:
					if (robotState.X == 0)
						return errorResult;
					robotState.X--;
					break;
				default:
					return DomainOperationResult.Error<RobotState>("Invalid Direction");
			}
			return DomainOperationResult.Success(robotState);
		}

	
		private DomainOperationResult<Direction> GetDirection(Command command)
		{
			if (command != Command.Left && command != Command.Right)
				return DomainOperationResult.Error<Direction>("command should be either Left or Right");

			Direction resultingDirection;

			switch (robotState.Direction)
			{
				case Direction.North:
					resultingDirection = command == Command.Left ? Direction.West : Direction.East;
					break;
				case Direction.East:
					resultingDirection = command == Command.Left ? Direction.North : Direction.South;
					break;
				case Direction.South:
					resultingDirection = command == Command.Left ? Direction.East : Direction.West;
					break;
				case Direction.West:
					resultingDirection = command == Command.Left ? Direction.South : Direction.North;
					break;
				default:
					return DomainOperationResult.Error<Direction>("Direction is undefined");
			}
			return DomainOperationResult.Success(resultingDirection);
		}

		private DomainOperationResult ValidatePlaceCommand(PlaceCommandDto commandDto)
		{
			if (commandDto == null)
				return DomainOperationResult.Error("The command object is Empty");

			if (robotState?.Direction.HasValue != true && !commandDto.Direction.HasValue)
				return DomainOperationResult.Error("Please enter the direction when executing the initial Place Command");

			if (commandDto.X < 0 || commandDto.X > 5)
				return DomainOperationResult.Error("The value of X Coordinate should be between 0 and 5");

			if (commandDto.Y < 0 || commandDto.Y > 5)
				return DomainOperationResult.Error("The value of Y Coordinate should be between 0 and 5");

			return DomainOperationResult.Success();
		}
	}
}

