using Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToyRobot.App
{
	public partial class frmToyRobot : Form
	{
		private readonly IToyRobotService _toyRobotService;
		public frmToyRobot(ServiceProvider serviceProvider)
		{
			InitializeComponent();
			_toyRobotService = serviceProvider.GetRequiredService<IToyRobotService>();
			InitialiseRobot();
		}

		public void InitialiseRobot()
		{
			pbStart.Image = Properties.Resources.Robot_Start;
			pbStart.SizeMode = PictureBoxSizeMode.StretchImage;
			cmbDirection.Items.Add(String.Empty);
			foreach (Direction direction in Enum.GetValues(typeof(Direction)))
			{
				cmbDirection.Items.Add(direction);
			}
		}

		private void btnPlace_Click(object sender, EventArgs e)
		{
			Direction? direction = string.IsNullOrEmpty(cmbDirection.Text) ? null as Direction?
				: (Direction)Enum.Parse(typeof(Direction), cmbDirection.Text);

			PlaceCommandDto dto = new PlaceCommandDto { X = (int)txtX.Value, Y = (int)txtY.Value, Direction = direction };
			var result = _toyRobotService.PlaceRobot(dto);

			lblOutputLabel.Visible = false;
			lblOutputValue.Visible = false;

			// If the operation fails show error
			if (result.Status != DomainOperationStatus.Success)
				MessageBox.Show(String.Join(Environment.NewLine, result.DomainErrors.Select(x => x.Message)));
			else
				// if the Domain Operation succeeds place the robot on the table
				PlaceRobotOnMatrix(result.Value);
		}

		/// <summary>
		///		Reads the <param name="state"></param> of the robot and places it on the tabletop
		/// </summary>
		/// <param name="state">The current state of the Robot. This is used to place the robot on the tabletop</param>
		private void PlaceRobotOnMatrix(RobotState state)
		{
			tableLayoutPanel1.Controls.Clear();
			PictureBox pictureBox = (PictureBox)tableLayoutPanel1.GetControlFromPosition(5 - state.X.Value, 5 - state.Y.Value);
			if (pictureBox == null)
			{
				pictureBox = new PictureBox();
				tableLayoutPanel1.Controls.Add(pictureBox,   state.X.Value, 5-state.Y.Value);
			}
			pictureBox.Image = Properties.Resources.Robot;
			switch (state.Direction)
			{
				case Direction.North:
					pictureBox.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
					break;
				case Direction.East:
					pictureBox.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
					break;
				case Direction.South:

					break;
				case Direction.West:
					pictureBox.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
					break;
			}
			pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
			pbStart.Image = null;
		}



		private DomainOperationResult<RobotState> ExecuteCommand(Command command)
		{
			var result = _toyRobotService.ExecuteCommand(command);

			lblOutputLabel.Visible = false;
			lblOutputValue.Visible = false;

			// If the operation fails show error
			if (result.Status != DomainOperationStatus.Success)
				MessageBox.Show(string.Join(Environment.NewLine, result.DomainErrors.Select(x => x.Message)));
			else
				// if the Domain Operation succeeds place the robot on the table
				PlaceRobotOnMatrix(result.Value);
			return result;
		}

		private void btnMove_Click(object sender, EventArgs e)
		{
			ExecuteCommand(Command.Move);
		}

		private void btnLeft_Click(object sender, EventArgs e)
		{
			ExecuteCommand(Command.Left);
		}

		private void btnRight_Click(object sender, EventArgs e)
		{
			ExecuteCommand(Command.Right);
		}

		private void btnReport_Click(object sender, EventArgs e)
		{
			var result = ExecuteCommand(Command.Report);
			if (result.Status == DomainOperationStatus.Success)
			{
				lblOutputLabel.Visible = true;
				lblOutputValue.Visible = true;
				lblOutputValue.Text = $"{result.Value.X},{result.Value.Y},{result.Value.Direction}";
			}
		}
	}
}
