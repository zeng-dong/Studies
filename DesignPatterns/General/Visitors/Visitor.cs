namespace Visitors
{
    public interface IVisitor
    {
        void VisitBook(Book book);

        void VisitViny(Vinyl vinyl);

        void Print();
    }

    public interface IVisitableElement
    {
        void Accetp(IVisitor visitor);
    }
}