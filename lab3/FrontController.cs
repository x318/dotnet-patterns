using System;

namespace lab3
{
    class TeacherView
    {
        public void display()
        {
            Console.WriteLine("Teacher View");
        }
    }

    class StudentView
    {
        public void display()
        {
            Console.WriteLine("Student View");
        }
    }

    class Dispatching
    {
        private StudentView _studentView;
        private TeacherView _teacherView;

        public Dispatching()
        {
            _studentView = new StudentView();
            _teacherView = new TeacherView();
        }

        public void dispatch(String request)
        {
            if (request.ToLower().Equals("Student"))
            {
                _studentView.display();
            }
            else
            {
                _teacherView.display();
            }
        }
    }

    class FrontController
    {
        private Dispatching _dispatching;

        public FrontController()
        {
            _dispatching = new Dispatching();
        }

        private bool isAuthenticUser()
        {
            Console.WriteLine("Authentication successful.");
            return true;
        }

        private void trackRequest(String request)
        {
            Console.WriteLine("Requested View: " + request);
        }

        public void dispatchRequest(String request)
        {
            trackRequest(request);

            if (isAuthenticUser())
            {
                _dispatching.dispatch(request);
            }
        }
    }
}
