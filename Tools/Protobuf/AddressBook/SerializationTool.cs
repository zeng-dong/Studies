using ProtoBuf;

namespace AddressBook;

public static class SerializationTool
{
    public static T Clone<T>(T source) where T : class
    {
        if (!typeof(T).IsDefined(typeof(ProtoContractAttribute), false))
            throw new InvalidOperationException("Cloning object with no protobuf contract attribute");

        using (var ms = new MemoryStream())
        {
            return Serializer.DeepClone(source);
        }
    }
}