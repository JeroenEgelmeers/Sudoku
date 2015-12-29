namespace SA_Week3_NarrowCasting.Interface
{
    public interface Subject
    {
        void setState();

        void attach(Observer o);

        void detach(Observer o);

        void notifyObservers();
    }
}
