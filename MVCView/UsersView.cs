using System;
using System.ComponentModel;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormMVC.Controller;
using WinFormMVC.Model;

namespace WinFormMVC.View
{
    public partial class UsersView : Form, IUsersView
    {
        public UsersView()
        {
            InitializeComponent();

            //Fractional Arithmetic
            textBoxFraResultNum.ReadOnly = true;
            textBoxFraResultDenom.ReadOnly = true;

            //Numbersystems
            radioButtonNumbersystemsDecimal.Checked = true;
            textBoxNumbersystems.MaxLength = 20;

            //BooleanAlgebra
            dataGridViewBooleanAlgebraInput.ColumnCount = 2;
            dataGridViewBooleanAlgebraOutput.ColumnCount = 1;
            dataGridViewBooleanAlgebraInput.RowCount = 5;
            dataGridViewBooleanAlgebraOutput.RowCount = 4;
            dataGridViewBooleanAlgebraOutput.ReadOnly = true;
            dataGridViewBooleanAlgebraInput.ReadOnly = true;
            dataGridViewBooleanAlgebraInput.AllowUserToAddRows = false;

            //Matrices
            dataGridViewMatricesMatrixA.ColumnCount = 1;
            dataGridViewMatricesMatrixB.ColumnCount = 1;
            dataGridViewMatricesMatrixGauß.ColumnCount = 1;
            dataGridViewMatricesMatrixResult.ColumnCount = 1;
            dataGridViewMatricesMatrixResult.ReadOnly = true;
            dataGridViewMatricesMatrixResult.AllowUserToDeleteRows = false;

            //SortingAlgorithm
            dataGridViewSortingTable.ColumnCount = 1;
            textBoxSortingMinValue.Text = "0";
            textBoxSortingMaxValue.Text = "100";
            textBoxSortingRows.Text = "10";
            textBoxSortingColumns.Text = "10";

            //PolynomialFunctions
            radioButtonFunctionsPoly.Checked = true;
            buttonFunctionsNewtonCancel.Enabled = false;
            dataGridViewFunctions.RowCount = 1;
            dataGridViewFunctions.ColumnCount = 2;
            dataGridViewFunctions.RowHeadersWidth = 67;
            textBoxFunctionsXMin.Text = "-12";
            textBoxFunctionsXMax.Text = "12";
            textBoxFunctionsYMin.Text = "-8";
            textBoxFunctionsYMax.Text = "8";
            textBoxFunctionSleep.Text = "100";

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(buttonFunctionsGraph, "Only Selected Rows will be drawn");

            //Subscript o Poly
            richTextBoxFunctionsPoly.Select(32, 1);
            richTextBoxFunctionsPoly.SelectionCharOffset = -5;

            //Subscript b Log
            richTextBoxFunctionsLog.Select(14, 1);
            richTextBoxFunctionsLog.SelectionCharOffset = -5;

            //Subscript o Log
            richTextBoxFunctionsLog.Select(32, 1);
            richTextBoxFunctionsLog.SelectionCharOffset = -5;

            // ^(c * (x-d)) Ex
            richTextBoxFunctionsEx.Select(12, 11);
            richTextBoxFunctionsEx.SelectionCharOffset = 5;

            //Subscript o Ex
            richTextBoxFunctionsEx.Select(27, 1);
            richTextBoxFunctionsEx.SelectionCharOffset = -5;

            //Graph Algorithm
            tabControlGraphAlgorithmns.Controls.Add(new GPage(new Graph(), "New Tab"));
        }

        Controller.Controller controller;

        public void SetController(Controller.Controller controller)
        {
            this.controller = controller;
        }

        #region Events raised back to controller

        #region Numbersystems 

        //RadioButton Enter
        private void radioButtonDecimal_Enter(object sender, EventArgs e)
        {
            textBoxNumbersystems.MaxLength = 20;
            controller.Decimal_Enter();
            radioButtonNumbersystemsDecimal.Checked = true;
        }

        private void radioButtonBinary_Enter(object sender, EventArgs e)
        {
            textBoxNumbersystems.MaxLength = 64;
            controller.Binary_Enter();
            radioButtonNumbersystemsBinary.Checked = true;
        }

        private void radioButtonHexadecimal_Enter(object sender, EventArgs e)
        {
            textBoxNumbersystems.MaxLength = 16;
            controller.Hexadecimal_Enter();
            radioButtonNumbersystemsHexadecimal.Checked = true;
        }

        //RadioButton Leave
        private void radioButtonInteger_Leave(object sender, EventArgs e)
        {
            controller.Decimal_Leave();
        }

        private void radioButtonBinary_Leave(object sender, EventArgs e)
        {
            controller.Binary_Leave();
        }

        private void radioButtonHexadecimal_Leave(object sender, EventArgs e)
        {
            controller.Hexadecimal_Leave();
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Fractional Arithmetic

        //Addition
        private void buttonFractionsAPlusB_Click(object sender, EventArgs e)
        {
            controller.FractionalArithmetic_Operator(Controller.Controller.FractionalArithmeticEnum.Addition);
        }

        //Subtraction
        private void buttonFractionsAMinusB_Click(object sender, EventArgs e)
        {
            controller.FractionalArithmetic_Operator(Controller.Controller.FractionalArithmeticEnum.Subtraction);
        }

        //Multiplication
        private void buttonFractionsATimesB_Click(object sender, EventArgs e)
        {
            controller.FractionalArithmetic_Operator(Controller.Controller.FractionalArithmeticEnum.Multiplication);
        }

        //Division
        private void buttonFractionsADividedByB_Click(object sender, EventArgs e)
        {
            controller.FractionalArithmetic_Operator(Controller.Controller.FractionalArithmeticEnum.Division);
        }

        //Reduce
        private void buttonFractionsReduceA_Click(object sender, EventArgs e)
        {
            controller.Reduce("A");
        }

        private void buttonFractionsReduceB_Click(object sender, EventArgs e)
        {
            controller.Reduce("B");
        }

        private void buttonFractionsReduceResult_Click(object sender, EventArgs e)
        {
            controller.Reduce("Result");
        }



        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Boolean Algebra

        private void buttonOR_Click(object sender, EventArgs e)
        {
            controller.BooleanAlgebraOperator(Controller.Controller.BooleanOperatorEnum.OR);
            tabControlBooleanAlgebra.SelectedIndex = 1;
        }

        private void buttonAND_Click(object sender, EventArgs e)
        {
            controller.BooleanAlgebraOperator(Controller.Controller.BooleanOperatorEnum.AND);
            tabControlBooleanAlgebra.SelectedIndex = 1;
        }

        private void buttonNOR_Click(object sender, EventArgs e)
        {
            controller.BooleanAlgebraOperator(Controller.Controller.BooleanOperatorEnum.NOR);
            tabControlBooleanAlgebra.SelectedIndex = 1;
        }

        private void buttonNAND_Click(object sender, EventArgs e)
        {
            controller.BooleanAlgebraOperator(Controller.Controller.BooleanOperatorEnum.NAND);
            tabControlBooleanAlgebra.SelectedIndex = 1;
        }

        private void buttonXOR_Click(object sender, EventArgs e)
        {
            controller.BooleanAlgebraOperator(Controller.Controller.BooleanOperatorEnum.XOR);
            tabControlBooleanAlgebra.SelectedIndex = 1;
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Matrices

        //A + B
        private void buttonMatricesAPlusB_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.APlusB);
        }

        //A - B
        private void buttonMatricesAMinusB_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.AMinusB);
        }

        //A * B
        private void buttonMatricesATimesB_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.ATimesB);
        }

        //A^-1
        private void buttonMatricesAInverse_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.AInverse);
        }

        //DotProduct AB
        private void buttonMatricesDotProductAB_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.DotProduct);
        }

        //CrossPruduct AB
        private void buttonMatricesCrossProductAB_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.CrossProduct);
        }

        //GaußAlgorithm
        private void buttonMatricesGaußAlgorithm_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.Gauß);
        }

        //Reduced GaußAlgorithm
        private void buttonMatricesReducedGauß_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 3;
            controller.Matrices_Operator(Controller.Controller.MatricesEnum.ReducedGauß);
        }

        //Copy ResultMatrix into MatrixB
        private void buttonMatricesCopyResultInMatrixB_Click(object sender, EventArgs e)
        {
            tabControlMatrices.SelectedIndex = 1;
            controller.CopyResultIntoB();
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region SortingAlgorithm

        private void buttonSortingRandom_Click(object sender, EventArgs e)
        {
            controller.Random();
        }

        //Quick Sort 
        private void buttonSortingQuickSort_Click(object sender, EventArgs e)
        {
            controller.SortingAlgorithm(Controller.Controller.SortingAlgorithmEnum.Qick);
        }

        //Bubble Sort
        private void buttonSortingBubbleSort_Click(object sender, EventArgs e)
        {
            controller.SortingAlgorithm(Controller.Controller.SortingAlgorithmEnum.Bubble);
        }

        //Insertion Sort
        private void buttonSortingInsertionSort_Click(object sender, EventArgs e)
        {
            controller.SortingAlgorithm(Controller.Controller.SortingAlgorithmEnum.Insertion);
        }

        //Selection Sort
        private void buttonSortingSelectionSort_Click(object sender, EventArgs e)
        {
            controller.SortingAlgorithm(Controller.Controller.SortingAlgorithmEnum.Selection);
        }

        //Shaker Sort 
        private void buttonSortingShakerSort_Click(object sender, EventArgs e)
        {
            controller.SortingAlgorithm(Controller.Controller.SortingAlgorithmEnum.Shaker);
        }

        //Reverse the Array
        private void buttonReverse_Click(object sender, EventArgs e)
        {
            controller.ReverseArray();
        }

        private void tabControlSortingAlforithm_Selected(object sender, TabControlEventArgs e)
        {
            controller.UpdateArraySortingAlgorithm();
        }


        private void pictureBoxSortingVisualisation_Paint(object sender, PaintEventArgs e)
        {
            controller.SortingDrawingLines(sender, e);
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region PolynomialFunctions

        private void buttonPolynomialFunctionsGraph_Click(object sender, EventArgs e)
        {
            textBoxFunctionsXMin.Text = "-12";
            textBoxFunctionsXMax.Text = "12";
            textBoxFunctionsYMin.Text = "-8";
            textBoxFunctionsYMax.Text = "8";
            controller.PolynomialFunctionMakeGraph();
        }

        private void pictureBoxPolynomialFunctions_MouseDown(object sender, MouseEventArgs e)
        {
            controller.PolynomialFunctionMouseDown(e.Location);
        }

        private void pictureBoxPolynomialFunctions_MouseUp(object sender, MouseEventArgs e)
        {
            controller.PolynomialFunctionMouseUp(e.Location);
        }

        private void pictureBoxPolynomialFunctions_MouseWheel(object sender, MouseEventArgs e)
        {
            controller.PolynomialFunctionMouseWheel(e);
        }

        BackgroundWorker bw = new BackgroundWorker
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true
        };

        private void buttonFunctionsNewton_Click(object sender, EventArgs e)
        {
            controller.ClearVisualization();

            if (textBoxNewtonXStart.Text.Trim() == "" || bw.IsBusy) { return; }

            bw = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            buttonFunctionsNewton.Enabled = false;
            controller.SetBackgroundWorker(bw);
            textBoxNewtonZero.Text = "";
            float xzero = 0;

            bw.DoWork += (bwSender, bwArg) =>
            {
                //what happens here must not touch the form
                //as it's in a different thread        
                xzero = controller.NewtonAlgorithm();
            };

            bw.ProgressChanged += (bwSender, bwArg) =>
            {
                //Refresh pictureBox
                pictureBoxFunctions.Image = controller.DrawVisualization();
                pictureBoxFunctions.Refresh();
            };

            bw.RunWorkerCompleted += (bwSender, bwArg) =>
            {
                //now you're back in the UI thread you can update the form
                //remember to dispose of bw now
                textBoxNewtonZero.Text = xzero.ToString();

                //work is done, no need for the stop button now...
                buttonFunctionsNewtonCancel.Enabled = false;
                buttonFunctionsNewton.Enabled = true;
                bw.CancelAsync();
                bw.Dispose();
            };

            buttonFunctionsNewtonCancel.Enabled = true;
            bw.RunWorkerAsync();
        }

        private void buttonFunctionsNewtonCancel_Click(object sender, EventArgs e)
        {
            bw.CancelAsync();
            textBoxNewtonZero.Text = "";
        }

        private void buttonFunctionsClear_Click(object sender, EventArgs e)
        {
            controller.ClearVisualization();
            textBoxNewtonZero.Text = "";
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Search Algorrithm

        //Run Algorithm
        private void cBtnGraphAlgorithmRun_Click(object sender, EventArgs e)
        {
            controller.GraphAlgorithmRun();
            ((this.tabControlGraphAlgorithmns.TabPages[this.tabControlGraphAlgorithmns.SelectedIndex]) as GPage).tabControl.SelectedIndex = 1;
        }

        //Djikstra Enter
        private void rbDijkstra_Enter(object sender, EventArgs e)
        {
            controller.Dijkstra_Enter();
        }

        //FloydCostTable Enter
        private void rbFloyd_Enter(object sender, EventArgs e)
        {
            controller.FloydWarschall_Enter();
        }

        //DFS Enter
        private void rbDFS_Enter(object sender, EventArgs e)
        {
            controller.DFS_Enter();
        }

        //BFS Enter
        private void rbBFS_Enter(object sender, EventArgs e)
        {
            controller.BFS_Enter();
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region

        private void buttonRSAEncryption_Click(object sender, EventArgs e)
        {
            controller.RSAEncryption();
        }

        #endregion

        #endregion

        #region Events not raised back to controller

        #region Events for the View Numbersystems

        private void textBoxNumbersystems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radioButtonNumbersystemsDecimal.Checked)
            {
                //Only allowing Ints in textbox
                textBoxDenominator_KeyPress(sender, e);
            }
            else if (radioButtonNumbersystemsBinary.Checked)
            {
                //Only allowing '1' and '0' in textbox
                if (!(e.KeyChar == '1' || e.KeyChar == '0' || char.IsControl(e.KeyChar)))
                {
                    e.Handled = true;
                }
            }
            else if (radioButtonNumbersystemsHexadecimal.Checked)
            {
                //Only allowing Ints and Letters A - F
                if (!(('0' <= e.KeyChar) && (e.KeyChar <= '9') ||
                      ('a' <= e.KeyChar) && (e.KeyChar <= 'f') ||
                      ('A' <= e.KeyChar) && (e.KeyChar <= 'F') ||
                      (char.IsControl(e.KeyChar))))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Events for the View Fractional Arithmetic

        //only allow one "-" at the beginning in Numerator
        private void textBoxNumerator_TextChanged(object sender, EventArgs e, TextBox textBox)
        {
            if (textBox.Text.Length > 0)
            {
                if (textBox.Text.Contains("-") && (textBox.Text.Substring(0, 1) != "-" || textBox.Text.Split('-').Length > 2))
                {
                    bool headingDash = false;
                    if (textBox.Text.Substring(0, 1) == "-")
                    {
                        headingDash = true;
                    }
                    textBox.Text = textBox.Text.Replace("-", "");
                    if (headingDash)
                    {
                        textBox.Text = "-" + textBox.Text;
                    }
                }
            }
        }
        private void textBoxFraANum_TextChanged(object sender, EventArgs e)
        {
            textBoxNumerator_TextChanged(sender, e, textBoxFraANum);
        }

        private void textBoxFraBNum_TextChanged(object sender, EventArgs e)
        {
            textBoxNumerator_TextChanged(sender, e, textBoxFraBNum);
        }


        //Keypress Only Allows Digits and "-" sign in Numerator
        private void textBoxNumerator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
        private void textBoxFraANum_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxNumerator_KeyPress(sender, e);
        }

        private void textBoxFraBNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxNumerator_KeyPress(sender, e);
        }


        //Only allowing Int's in Denominator
        private void textBoxDenominator_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxFraADenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }
        private void textBoxFraBDenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }


        //removing zeros at the beginning in Denominator
        private void textBoxDenominator_TextChanged(object sender, EventArgs e, TextBox textBox)
        {
            if (textBox.Text.Length > 0)
            {
                if (Convert.ToInt64(textBox.Text) != 0)
                {
                    textBox.Text = Convert.ToString(Convert.ToInt64(textBox.Text));
                }
                else
                {
                    textBox.Text = textBox.Text.Replace("0", "");
                }
            }
        }
        private void textBoxFraADenom_TextChanged(object sender, EventArgs e)
        {
            textBoxDenominator_TextChanged(sender, e, textBoxFraADenom);
        }
        private void textBoxFraBDenom_TextChanged(object sender, EventArgs e)
        {
            textBoxDenominator_TextChanged(sender, e, textBoxFraBDenom);
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Events for the View Boolean Algebra

        //Only allow
        public void dataGridViewBooleanAlgebraInput_KeyDown(object sender, KeyEventArgs e, DataGridView dataGridView)
        {
            //control selected cell with arrow keys
            if (e.KeyValue == 37 && dataGridView.CurrentCell.ColumnIndex - 1 != -1)
            {
                dataGridView.CurrentCell.Selected = false;
                dataGridView.CurrentCell = dataGridView[dataGridView.CurrentCell.ColumnIndex - 1, dataGridView.CurrentCell.RowIndex];
                dataGridView.CurrentCell.Selected = true;
            }
            else if (e.KeyValue == 38 && dataGridView.CurrentCell.RowIndex - 1 != -1)
            {
                dataGridView.CurrentCell.Selected = false;
                dataGridView.CurrentCell = dataGridView[dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex - 1];
                dataGridView.CurrentCell.Selected = true;
            }
            else if (e.KeyValue == 39 && dataGridView.CurrentCell.ColumnIndex + 1 < dataGridView.ColumnCount)
            {
                dataGridView.CurrentCell.Selected = false;
                dataGridView.CurrentCell = dataGridView[dataGridView.CurrentCell.ColumnIndex + 1, dataGridView.CurrentCell.RowIndex];
                dataGridView.CurrentCell.Selected = true;
            }
            else if (e.KeyValue == 40 && dataGridView.CurrentCell.RowIndex + 1 < dataGridView.RowCount)
            {
                dataGridView.CurrentCell.Selected = false;
                dataGridView.CurrentCell = dataGridView[dataGridView.CurrentCell.ColumnIndex, dataGridView.CurrentCell.RowIndex + 1];
                dataGridView.CurrentCell.Selected = true;
            }

            if (e.KeyValue == '1')
            {
                dataGridView.CurrentCell.Value = "1";
            }
            else if (e.KeyValue == '0')
            {
                dataGridView.CurrentCell.Value = "0";
            }
            else
            {
                e.Handled = true;
            }
        }
        private void dataGridViewBooleanAlgebraInput_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridViewBooleanAlgebraInput_KeyDown(sender, e, dataGridViewBooleanAlgebraInput);
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Events for the View Matrices 

        //Matrices
        int currentColumnIndex;

        //Setting CurrentColumnIndex
        private void dataGridViewMatrices_CellEnter(DataGridView dataGridView)
        {
            if (dataGridView.CurrentCell != null)
            {
                currentColumnIndex = dataGridView.CurrentCell.ColumnIndex;
            }
        }
        //Cell Enter
        private void dataGridViewMatricesMatrixA_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMatrices_CellEnter(dataGridViewMatricesMatrixA);
        }
        private void dataGridViewMatricesMatrixB_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMatrices_CellEnter(dataGridViewMatricesMatrixB);
        }
        private void dataGridViewMatricesMatrixGauß_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMatrices_CellEnter(dataGridViewMatricesMatrixGauß);
        }


        //deactivate sortmode for every new column
        private void DeactivateColumnSortMode(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }
        private void dataGridViewMatricesMatrixA_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DeactivateColumnSortMode(sender, e);
        }
        private void dataGridViewMatricesMatrixB_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DeactivateColumnSortMode(sender, e);
        }
        private void dataGridViewMatricesMatrixGauß_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DeactivateColumnSortMode(sender, e);
        }
        private void dataGridViewMatricesMatrixResult_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DeactivateColumnSortMode(sender, e);
        }


        //Validating if Input is correct
        private void dataGridView_CellValidating(DataGridView dataGridView, object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.FormattedValue.ToString() != string.Empty && !decimal.TryParse(e.FormattedValue.ToString(), out decimal value))
            {
                e.Cancel = true;
            }
        }

        private void dataGridViewMatricesMatrixA_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView_CellValidating(dataGridViewMatricesMatrixA, sender, e);
        }
        private void dataGridViewMatricesMatrixB_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView_CellValidating(dataGridViewMatricesMatrixB, sender, e);
        }
        private void dataGridViewMatricesMatrixGauß_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView_CellValidating(dataGridViewMatricesMatrixGauß, sender, e);
        }

        //Controlling KeyPressEvent in DataGridView wihle EdidtingMode is active
        private void dataGridViewTextBox_KeyPress(DataGridView dataGraidView, object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || char.IsControl(e.KeyChar) || e.KeyChar == ',' || e.KeyChar == '-'))
            {
                e.Handled = true;
            }
            else if (currentColumnIndex == dataGraidView.ColumnCount - 1)
            {
                if (!(tabControl.SelectedIndex == 5 && (radioButtonFunctionsEx.Checked == true || radioButtonFunctionsLog.Checked == true || radioButtonFunctionsSine.Checked == true || radioButtonFunctionsCosine.Checked == true)))
                {
                    dataGraidView.ColumnCount++;
                }
            }
        }

        private void dataGridViewMatricesMatrixA_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridViewMactricesMatrixATextBox_KeyPress);
        }
        private void dataGridViewMactricesMatrixATextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewTextBox_KeyPress(dataGridViewMatricesMatrixA, sender, e);
        }

        private void dataGridViewMatricesMatrixB_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridViewMactricesMatrixBTextBox_KeyPress);
        }
        private void dataGridViewMactricesMatrixBTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewTextBox_KeyPress(dataGridViewMatricesMatrixB, sender, e);
        }

        private void dataGridViewMatricesMatrixGauß_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridViewMactricesMatrixGaußTextBox_KeyPress);
        }
        private void dataGridViewMactricesMatrixGaußTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewTextBox_KeyPress(dataGridViewMatricesMatrixGauß, sender, e);
        }


        //select entire Column when clicked on ColumnHeader
        private void dataGridViewColumnHeader_MouseClick(DataGridView dataGridView, object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView.EndEdit();
            if (dataGridView.ColumnCount != 1)
            {
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
                dataGridView.Columns[e.ColumnIndex].Selected = true;
            }
        }
        private void dataGridViewMatricesMatrixA_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewColumnHeader_MouseClick(dataGridViewMatricesMatrixA, sender, e);
        }
        private void dataGridViewMatricesMatrixB_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewColumnHeader_MouseClick(dataGridViewMatricesMatrixB, sender, e);
        }
        private void dataGridViewMatricesMatrixGauß_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewColumnHeader_MouseClick(dataGridViewMatricesMatrixGauß, sender, e);
        }

        //select entire Row when clicked on RowHeader
        private void dataGridViewRowHeader_MouseClick(DataGridView dataGridView, object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView.EndEdit();
            if (dataGridView.RowCount != 1)
            {
                dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView.Rows[e.RowIndex].Selected = true;
            }
        }
        private void dataGridViewMatricesMatrixA_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewRowHeader_MouseClick(dataGridViewMatricesMatrixA, sender, e);
        }
        private void dataGridViewMatricesMatrixB_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewRowHeader_MouseClick(dataGridViewMatricesMatrixB, sender, e);
        }
        private void dataGridViewMatricesMatrixGauß_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewRowHeader_MouseClick(dataGridViewMatricesMatrixGauß, sender, e);
        }


        //Getting rid of column selection mode
        private void dataGridViewCell_MouseClick(DataGridView dataGridView, object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!(e.ColumnIndex == -1))
            {
                if (dataGridView.Columns[e.ColumnIndex].Selected)
                {
                    dataGridView.Columns[e.ColumnIndex].Selected = false;
                    dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                }
            }
            if (!(e.RowIndex == -1))
            {
                if (dataGridView.Rows[e.RowIndex].Selected)
                {
                    dataGridView.Rows[e.RowIndex].Selected = false;
                    dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
                }
            }
        }
        private void dataGridViewMatricesMatrixA_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewCell_MouseClick(dataGridViewMatricesMatrixA, sender, e);
        }
        private void dataGridViewMatricesMatrixB_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewCell_MouseClick(dataGridViewMatricesMatrixB, sender, e);
        }
        private void dataGridViewMatricesMatrixGauß_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewCell_MouseClick(dataGridViewMatricesMatrixGauß, sender, e);
        }


        //deleting selected Columns when del pressed
        private void dataGridView_KeyDown(DataGridView dataGridView, object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete))
            {
                int arraySize = 0;
                for (int i = 0; i < dataGridView.ColumnCount - 1; i++)
                {
                    if (dataGridView.Columns[i].Selected)
                        arraySize++;
                }

                int[] selectedColumns = new int[arraySize];
                int z = 0;
                for (int i = dataGridView.ColumnCount - 1; i > 0; i--)
                {
                    if (dataGridView.Columns[i - 1].Selected)
                    {
                        selectedColumns[z] = i - 1;
                        z++;
                    }
                }

                for (int i = 0; i < arraySize; i++)
                {
                    if (dataGridView.ColumnCount != 1)
                        dataGridView.Columns.RemoveAt(selectedColumns[i]);
                }
            }
        }
        private void dataGridViewMatricesMatrixA_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView_KeyDown(dataGridViewMatricesMatrixA, sender, e);
        }
        private void dataGridViewMatricesMatrixB_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView_KeyDown(dataGridViewMatricesMatrixB, sender, e);
        }
        private void dataGridViewMatricesMatrixGauß_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView_KeyDown(dataGridViewMatricesMatrixGauß, sender, e);
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Events for the View SortingAlgorithm

        //Cell Enter
        private void dataGridViewSortingTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMatrices_CellEnter(dataGridViewSortingTable);
        }

        //deactivate Sortmode for every Column
        private void dataGridViewSortingTable_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DeactivateColumnSortMode(sender, e);
        }

        //Validating if Input is correct
        private void dataGridViewSortingTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView_CellValidating(dataGridViewSortingTable, sender, e);
        }

        //Controlling KeyPressEvent in DataGridView wihle EdidtingMode is active
        private void dataGridViewSortingTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridViewSortingTableTextBox_KeyPress);
        }
        private void dataGridViewSortingTableTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewTextBox_KeyPress(dataGridViewSortingTable, sender, e);
        }

        //ColumnHeaderMouseClick
        private void dataGridViewSortingTable_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewColumnHeader_MouseClick(dataGridViewSortingTable, sender, e);
        }

        //RowHeaderMousClick
        private void dataGridViewSortingTable_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewRowHeader_MouseClick(dataGridViewSortingTable, sender, e);
        }

        //CellMouseClick
        private void dataGridViewSortingTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewCell_MouseClick(dataGridViewSortingTable, sender, e);
        }

        //KeyDown
        private void dataGridViewSortingTable_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView_KeyDown(dataGridViewSortingTable, sender, e);
        }

        //Only allowing Integers in textBox
        private void textBoxSortingMinValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }
        private void textBoxSortingMaxValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }
        private void textBoxSortingRows_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }
        private void textBoxSortingColumns_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Events for the View Functions

        //Setting CurrentCellIndex
        private void dataGridViewFunctions_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewMatrices_CellEnter(dataGridViewFunctions);
        }

        //Naming ColumnHeader
        private void dataGridViewFunctions_NamingColumns()
        {
            int anzahl = -1;

            foreach (DataGridViewColumn column in dataGridViewFunctions.Columns)
            {
                column.HeaderText = "x^" + anzahl;
                anzahl++;
            }

            dataGridViewFunctions.Columns[0].HeaderText = "a";
            if (dataGridViewFunctions.ColumnCount >= 2) { dataGridViewFunctions.Columns[1].HeaderText = "yo"; }
        }

        //Naming ColumnHeader to sooresponding Polynomial and dea
        private void dataGridViewFunctions_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            DeactivateColumnSortMode(sender, e);
            dataGridViewFunctions_NamingColumns();
        }

        //Columns Removed
        private void dataGridViewFunctions_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridViewFunctions_NamingColumns();
        }

        //Naming Row Header
        private void dataGridViewFunctions_NamingRows()
        {
            int i = 1;
            foreach (DataGridViewRow row in dataGridViewFunctions.Rows)
            {
                row.Cells[0].Value = "1";
                row.HeaderCell.Value = "F" + i + "(X)";
                i++;
            }
        }

        //Rows Added
        private void dataGridViewFunctions_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridViewFunctions_NamingRows();
        }

        //Rows Removed
        private void dataGridViewFunctions_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            dataGridViewFunctions_NamingRows();
        }

        //Validating Cell Input
        private void dataGridViewFunctions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            dataGridView_CellValidating(dataGridViewFunctions, sender, e);
        }

        //Creating new KeyPressEventHandler while in EditingMode
        private void dataGridViewFunctions_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress += new KeyPressEventHandler(dataGridViewFunctionsTextBox_KeyPress);
        }
        private void dataGridViewFunctionsTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridViewTextBox_KeyPress(dataGridViewFunctions, sender, e);
        }

        //ColumnHeaderMouseClick
        private void dataGridViewFunctions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewColumnHeader_MouseClick(dataGridViewFunctions, sender, e);
        }

        //RowHeaderMouseClick
        private void dataGridViewFunctions_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewRowHeader_MouseClick(dataGridViewFunctions, sender, e);
        }

        //CellMouseClick
        private void dataGridViewFunctions_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridViewCell_MouseClick(dataGridViewFunctions, sender, e);
        }

        //KeyDown
        private void dataGridViewFunctions_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView_KeyDown(dataGridViewFunctions, sender, e);
        }

        //TextBoxKeyPress allowing only Numbers, minus-sign and ','
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            string test = sender.ToString().Remove(0, 36);
            test += e.KeyChar;

            if ((e.KeyChar == '+' || e.KeyChar == '-') && test.Length == 1)
            {
                return;   
            }

            if (!(decimal.TryParse(test, out decimal result) || char.IsControl(e.KeyChar)) || e.KeyChar == '.')
            {
                
                e.Handled = true;
            }
        }

        private void textBoxFunctionsXMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }
        private void textBoxFunctionsXMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }
        private void textBoxFunctionsYMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }
        private void textBoxFunctionsYMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }
        private void textBoxNewtonXStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox_KeyPress(sender, e);
        }

        //only allow ints in textBox
        private void textBoxFunctionSleep_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }

        private void NamingColumnHeaderLogAndEx()
        {
            dataGridViewFunctions.ColumnCount = 5;
            dataGridViewFunctions.Columns[0].HeaderText = "a";
            dataGridViewFunctions.Columns[1].HeaderText = "b";
            dataGridViewFunctions.Columns[2].HeaderText = "c";
            dataGridViewFunctions.Columns[3].HeaderText = "d";
            dataGridViewFunctions.Columns[4].HeaderText = "yo";
        }

        private void NamingColumnHeaderSineAndCosine()
        {
            dataGridViewFunctions.ColumnCount = 4;
            dataGridViewFunctions.Columns[0].HeaderText = "a";
            dataGridViewFunctions.Columns[1].HeaderText = "b";
            dataGridViewFunctions.Columns[2].HeaderText = "c";
            dataGridViewFunctions.Columns[3].HeaderText = "yo";
        }

        private void radioButtonFunctionsPoly_Enter(object sender, EventArgs e)
        {
            controller.SetCurrentFunctionType(Function.FunctionType.Polynomial);

            dataGridViewFunctions.ColumnCount++;
        }

        private void radioButtonFunctionsLog_Enter(object sender, EventArgs e)
        {
            controller.SetCurrentFunctionType(Function.FunctionType.Logarithm);
            NamingColumnHeaderLogAndEx();
        }

        private void radioButtonFunctionsEx_Enter(object sender, EventArgs e)
        {
            controller.SetCurrentFunctionType(Function.FunctionType.Exponential);
            NamingColumnHeaderLogAndEx();
        }

        private void radioButtonFunctionsSine_Enter(object sender, EventArgs e)
        {
            controller.SetCurrentFunctionType(Function.FunctionType.Sine);
            NamingColumnHeaderSineAndCosine();
        }

        private void radioButtonFunctionsCosine_Enter(object sender, EventArgs e)
        {
            controller.SetCurrentFunctionType(Function.FunctionType.Cosine);
            NamingColumnHeaderSineAndCosine();
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Events for the View SearchAlgorithmns

        //Colse Tab
        private void cBtnSearchAlgorithmColseTab_Click(object sender, EventArgs e)
        {
            if (this.tabControlGraphAlgorithmns.TabCount != 1)
            {
                this.tabControlGraphAlgorithmns.TabPages.RemoveAt(this.tabControlGraphAlgorithmns.SelectedIndex);
                this.tabControlGraphAlgorithmns.SelectedIndex = this.tabControlGraphAlgorithmns.TabCount - 1;
            }
            else
            {
                MessageBox.Show("Cannot close the last standing tab!", "Warning");
            }
        }

        //Add Tab
        private void cBtnSearchAlgorithmAddTab_Click(object sender, EventArgs e)
        {
            if (this.tabControlGraphAlgorithmns.TabCount < StaticValues.GRAPH_LIMIT)
            {
                this.tabControlGraphAlgorithmns.TabPages.Add(new GPage(new Graph(), "New Tab"));
                this.tabControlGraphAlgorithmns.SelectedIndex = this.tabControlGraphAlgorithmns.TabCount - 1;
            }
            else
            {
                MessageBox.Show("Tab limit is set to " + StaticValues.GRAPH_LIMIT + "!", "Warning");
            }
        }
        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Events for the View RSAEncryption

        //Only allow positive Integers
        private void textBoxRSAPrimeP_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }

        private void textBoxRSAPrimeQ_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }

        private void textBoxRSAE_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBoxDenominator_KeyPress(sender, e);
        }

        #endregion

        #endregion

        #region Get and Set For the View

        #region Getter, Setter for NumbersystemsTextbox

        public string NumbersystemText
        {
            get { return textBoxNumbersystems.Text; }
            set { textBoxNumbersystems.Text = value; }
        }

        public int TextBoxNumbersystemLength
        {
            set { textBoxNumbersystems.MaxLength = value; }
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Getter, Setter for Fraction

        public Fraction FractionA
        {
            get
            {
                Fraction fraction = new Fraction();
                if (textBoxFraANum.Text == "")
                {
                    fraction.Numerator = 0;

                    if (textBoxFraADenom.Text == "")
                    {
                        fraction.Denominator = 1;
                    }
                }
                else if (textBoxFraADenom.Text == "")
                {
                    fraction.Denominator = 1;

                    if (textBoxFraANum.Text == "")
                    {
                        fraction.Numerator = 0;
                    }
                }
                else
                {
                    fraction.Numerator = Convert.ToInt32(textBoxFraANum.Text);
                    fraction.Denominator = Convert.ToInt32(textBoxFraADenom.Text);
                }

                return fraction;
            }
            set
            {
                textBoxFraANum.Text = value.Numerator.ToString();
                textBoxFraADenom.Text = value.Denominator.ToString();
            }
        }

        public Fraction FractionB
        {
            get
            {
                Fraction fraction = new Fraction();
                if (textBoxFraANum.Text == "")
                {
                    fraction.Numerator = 0;

                    if (textBoxFraBDenom.Text == "")
                    {
                        fraction.Denominator = 1;
                    }
                }
                else if (textBoxFraBDenom.Text == "")
                {
                    fraction.Denominator = 1;

                    if (textBoxFraBNum.Text == "")
                    {
                        fraction.Numerator = 0;
                    }
                }
                else
                {
                    fraction.Numerator = Convert.ToInt32(textBoxFraBNum.Text);
                    fraction.Denominator = Convert.ToInt32(textBoxFraBDenom.Text);
                }

                return fraction;
            }
            set
            {
                textBoxFraBNum.Text = value.Numerator.ToString();
                textBoxFraBDenom.Text = value.Denominator.ToString();
            }
        }

        public Fraction FractionResult
        {
            get { return new Fraction(Convert.ToInt32(textBoxFraResultNum.Text), Convert.ToInt32(textBoxFraResultDenom.Text)); }
            set
            {
                textBoxFraResultNum.Text = value.Numerator.ToString();
                textBoxFraResultDenom.Text = value.Denominator.ToString();
            }
        }

        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Getter, Setter for Boolean Algebra DataGridView

        public DataGridView BooleanAlgebraInput
        {
            get { return dataGridViewBooleanAlgebraInput; }
        }

        public DataGridView BooleanAlgebraOutput
        {
            get { return dataGridViewBooleanAlgebraOutput; }
        }


        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Getter, Setter for Matrices 

        public DataGridView MatrixA
        {
            get { return dataGridViewMatricesMatrixA; }
        }

        public DataGridView MatrixB
        {
            get { return dataGridViewMatricesMatrixB; }
            set
            {
                dataGridViewMatricesMatrixB.RowCount = value.RowCount;
                dataGridViewMatricesMatrixB.ColumnCount = value.ColumnCount;

                for (int i = 0; i < value.RowCount; i++)
                {
                    for (int j = 0; j < value.ColumnCount; j++)
                    {
                        dataGridViewMatricesMatrixB[j, i].Value = value[j, i].Value;
                    }
                }
            }
        }

        public DataGridView MatrixGauß
        {
            get { return dataGridViewMatricesMatrixGauß; }
        }

        public DataGridView MatrixResult
        {
            get { return dataGridViewMatricesMatrixResult; }
            set
            {
                dataGridViewMatricesMatrixResult.RowCount = value.RowCount;
                dataGridViewMatricesMatrixResult.ColumnCount = value.ColumnCount;

                for (int i = 0; i < value.RowCount; i++)
                {
                    for (int j = 0; j < value.ColumnCount; j++)
                    {
                        dataGridViewMatricesMatrixResult[j, i].Value = value[j, i].Value;
                    }
                }
            }
        }


        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Getter, Setter for SortingAlgorithm

        public DataGridView SortingTable
        {
            get { return dataGridViewSortingTable; }
            set
            {
                dataGridViewSortingTable.RowCount = value.RowCount;
                dataGridViewSortingTable.ColumnCount = value.ColumnCount;

                for (int i = 0; i < value.RowCount; i++)
                {
                    for (int j = 0; j < value.ColumnCount; j++)
                    {
                        dataGridViewSortingTable[j, i].Value = value[j, i].Value;
                    }
                }
            }
        }

        public PictureBox SortingPictureBox
        {
            get { return pictureBoxSortingVisualisation; }
            set { pictureBoxSortingVisualisation = value; }
        }

        public int SortingMinValue
        {
            get
            {
                if (textBoxSortingMinValue.Text != "" && Convert.ToInt32(textBoxSortingMinValue.Text) != 0)
                {
                    return Convert.ToInt32(textBoxSortingMinValue.Text);
                }
                else
                {
                    return 0;
                }
            }
            set { textBoxSortingMinValue.Text = value.ToString(); }
        }

        public int SortingMaxValue
        {
            get
            {
                if (textBoxSortingMaxValue.Text != "" && Convert.ToInt32(textBoxSortingMaxValue.Text) != 0)
                {
                    return Convert.ToInt32(textBoxSortingMaxValue.Text);
                }
                else
                {
                    return 100;
                }
            }
            set { textBoxSortingMaxValue.Text = value.ToString(); }
        }

        public int SortingColumns
        {
            get
            {
                if (textBoxSortingColumns.Text != "" && Convert.ToInt32(textBoxSortingColumns.Text) != 0)
                {
                    return Convert.ToInt32(textBoxSortingColumns.Text);
                }
                else
                {
                    return 10;
                }
            }
            set { textBoxSortingColumns.Text = value.ToString(); }
        }

        public int SortingRows
        {
            get
            {
                if (textBoxSortingRows.Text != "" && Convert.ToInt32(textBoxSortingRows.Text) != 0)
                {
                    return Convert.ToInt32(textBoxSortingRows.Text);
                }
                else
                {
                    return 10;
                }
            }
            set { textBoxSortingRows.Text = value.ToString(); }
        }



        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Getter, Setter for Functions

        public DataGridView FunctionsGrid
        {
            get { return dataGridViewFunctions; }
            set
            {
                dataGridViewFunctions.RowCount = value.RowCount;
                dataGridViewFunctions.ColumnCount = value.ColumnCount;

                for (int i = 0; i < value.RowCount; i++)
                {
                    for (int j = 0; j < value.ColumnCount; j++)
                    {
                        dataGridViewFunctions[j, i].Value = value[j, i].Value;
                    }
                }
            }
        }

        public PictureBox FunctionsGraph
        {
            get { return pictureBoxFunctions; }
            set { pictureBoxFunctions = value; }
        }

        public float FunctionsXMin
        {
            get { float.TryParse(textBoxFunctionsXMin.Text, out float result); return result; }
            set { textBoxFunctionsXMin.Text = value.ToString(); }
        }

        public float FunctionsXMax
        {
            get { Single.TryParse(textBoxFunctionsXMax.Text, out float result); return result; }
            set { textBoxFunctionsXMax.Text = value.ToString(); }
        }

        public float FunctionsYMin
        {
            get { Single.TryParse(textBoxFunctionsYMin.Text, out float result); return result; }
            set { textBoxFunctionsYMin.Text = value.ToString(); }
        }

        public float FunctionsYMax
        {
            get { Single.TryParse(textBoxFunctionsYMax.Text, out float result); return result; }
            set { textBoxFunctionsYMax.Text = value.ToString(); }
        }

        public float NewtonXStart
        {
            get { Single.TryParse(textBoxNewtonXStart.Text, out float result); return result; }
        }

        public float NewtonZero
        {
            set { textBoxNewtonZero.Text = value.ToString(); }
        }

        public int SleepTime
        {
            get
            {
                if (textBoxFunctionSleep.Text.Trim() != string.Empty) { return Convert.ToInt32(textBoxFunctionSleep.Text); }
                return 0;
            }
        }


        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Getter, Setter for Graph Algortihm

        public Graph Graph
        {
            get { return ((this.tabControlGraphAlgorithmns.TabPages[this.tabControlGraphAlgorithmns.SelectedIndex]) as GPage).invokeGraph; }
        }

        public string InvokeRTB
        {
            set { ((this.tabControlGraphAlgorithmns.TabPages[this.tabControlGraphAlgorithmns.SelectedIndex]) as GPage).rtbLogs.Text = value; }
        }

        public uint StartValueGraphAlgorithm
        {
            get
            {
                uint value;

                if (uint.TryParse(textBoxInitial.Text, out value))
                {
                    value = Convert.ToUInt32(textBoxInitial.Text);
                }

                return value;
            }
        }


        #endregion
        //==================================================================================================================\\
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\\
        //==================================================================================================================\\
        #region Getter, Setter for RSA Encryption

        public BigInteger PrimeP
        {
            get
            {
                if (textBoxRSAPrimeP.Text != string.Empty) { return BigInteger.Parse(textBoxRSAPrimeP.Text); }
                else { return new BigInteger(0); }
            }
        }

        public BigInteger PrimeQ
        {
            get
            {
                if (textBoxRSAPrimeQ.Text != string.Empty) { return BigInteger.Parse(textBoxRSAPrimeQ.Text); }
                else { return new BigInteger(0); }
            }
        }

        public BigInteger E
        {
            get
            {
                if (textBoxRSAE.Text != string.Empty) { return BigInteger.Parse(textBoxRSAE.Text); }
                else { return new BigInteger(0); }
            }
        }

        public string Message
        {
            get { return richTextBoxRSAMessage.Text; }
        }

        public string EncryptedMessage
        {
            set { richTextBoxRSAEncryptedMessage.Text = value; }
        }

        public string DecryptedMessage
        {
            set { richTextBoxRSADecryptedMessage.Text = value; }
        }

        public string PrivateKey
        {
            set { textBoxRSAPrivateKey.Text = value; }
        }

        public string PublicKey
        {
            set { textBoxRSAPublicKey.Text = value; }
        }

        public string WarningMessage
        {
            set { labelRSAWarningMessage.Text = value; }
            get { return labelRSAWarningMessage.Text; }
        }


        #endregion

        #endregion
    }
}
