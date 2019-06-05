using System.Collections.Generic;

namespace Mirror.UnitTest.Mock
{
    public class Mocks : List<Moq.Mock>
    {
        public static Mocks New()
        {
            return new Mocks();
        }

        public void VerifyAll()
        {
            foreach (var mock in this)
            {
                mock.VerifyAll();
            }
        }
    }
}