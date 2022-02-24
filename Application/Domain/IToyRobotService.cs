using System;

namespace Domain
{
    public interface IToyRobotService
    {
        /// <summary>
        ///     Places the Robot on the given X, Y Co Ordinates in the Direction Specified
        /// </summary>
        /// <param name="commandDto">Direction is mandatory on the first place. Not on subsequent places</param>
        /// <returns></returns>
        DomainOperationResult<RobotState> PlaceRobot(PlaceCommandDto commandDto);
        DomainOperationResult<RobotState> ExecuteCommand(Command command);
        void ResetRobotState();
    }
}
