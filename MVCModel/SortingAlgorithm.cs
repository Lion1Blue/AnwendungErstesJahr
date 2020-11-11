using System.Threading;

namespace WinFormMVC.Model
{
    public class SortingAlgorithm
    {
        public SortingAlgorithm(IController controller)
        {
            _controller = controller;
        }
        
        IController _controller;

        //QuickSort
        public void QuickSort(decimal[] array, int left, int right)
        {
            if (left < right)
            {
                int pivot = Partition(array, left, right);

                if (pivot > 1)
                {
                    QuickSort(array, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    QuickSort(array, pivot + 1, right);
                }
            }
        }

        //Partition
        private int Partition(decimal[] array, int left, int right)
        {
            decimal pivot = array[left];

            while (true)
            {
                while (array[left] < pivot)
                {
                    left++;
                }

                while (array[right] > pivot)
                {
                    right--;
                }

                if (left < right)
                {
                    decimal temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;

                    _controller.RefreshPictureBoxSorting();

                    if (array[left] == array[right])
                    {
                        left++;
                    }
                }
                else
                {
                    return right;
                }
            }
        }

        //BubbleSort
        public void BubbleSort(decimal[] array)
        {
            int n = array.Length;
            bool swapped;

            do
            {
                swapped = false;
                for (int i = 0; i < n - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        decimal tmp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = tmp;
                        swapped = true;
                        _controller.RefreshPictureBoxSorting();
                        Thread.Sleep(50);
                    }
                }
                n -= 1;

            } while (swapped);
        }

        //Selection Sort
        public void SelectionSort(decimal[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                        _controller.RefreshPictureBoxSorting();
                }

                decimal tmp = array[min];
                array[min] = array[i];
                array[i] = tmp;

            }
        }

        //Insertion Sort
        public void InsertionSort(decimal[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                decimal key = array[i];
                int j = i - 1;

                // Move elements of arr[0..i-1], 
                // that are greater than key, 
                // to one position ahead of 
                // their current position 
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                    _controller.RefreshPictureBoxSorting();
                }
                array[j + 1] = key;
            }
        }

        //Shaker Sort 
        public void ShakerSort(decimal[] array)
        {
            bool isSwapped = true;
            int start = 0;
            int end = array.Length;

            while (isSwapped)
            {

                //Reset this flag.  It is possible for this to be true from a prior iteration.
                isSwapped = false;

                //Do a bubble sort on this array, from low to high.  If something changed, make isSwapped true.
                for (int i = start; i < end - 1; ++i)
                {
                    if (array[i] > array[i + 1])
                    {
                        decimal temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                        _controller.RefreshPictureBoxSorting();
                    }
                }

                //If no swaps are made, the array is sorted.
                if (isSwapped == false)
                    break;

                //We need to reset the isSwapped flag for the high-to-low pass
                isSwapped = false;

                //The item we just moved is in its rightful place, so we no longer need to consider it unsorted.
                end = end - 1;

                //Now we bubble sort from high to low
                for (int i = end - 1; i >= start; i--)
                {
                    if (array[i] > array[i + 1])
                    {
                        decimal temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        isSwapped = true;
                        _controller.RefreshPictureBoxSorting();
                    }
                }

                //Finally, we need to increase the starting point for the next low-to-high pass.
                start = start + 1;
            }
        }

        public void Reverse(decimal[] array)
        {
            int arrayLength = array.Length;
            for (int i = 0; i < arrayLength / 2; i++)
            {
                decimal tmp = array[i];
                array[i] =  array[arrayLength - 1 - i];
                array[arrayLength - 1 - i] = tmp;
                _controller.RefreshPictureBoxSorting();
            }
        }
    }
}
