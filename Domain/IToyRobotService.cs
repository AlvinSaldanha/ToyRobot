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

        /// <summary>
        ///     Executes the Command that is passed in
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        DomainOperationResult<RobotState> ExecuteCommand(Command command);
        
        /// <summary>
        ///     Resets the robot's state to initial state
        /// </summary>
        void ResetRobotState();
    }
}
