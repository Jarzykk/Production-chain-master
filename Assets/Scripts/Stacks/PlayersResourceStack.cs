public class PlayersResourceStack : ResourceStack
{
    public void TryGiveResourceToInputStorage(InputStorage inputStorage)
    {
        if (StackIsEmpty)
            return;

        var resourceNames = inputStorage.GetResourcesToStoreNames();

        foreach (var resourceName in resourceNames)
        {
            if(CkeckResourceAvailability(resourceName))
            {
                if (inputStorage.FreeSpaceAvailible)
                {
                    Resource ressurceToGive = GiveLastAddedResourceByName(resourceName);
                    bool resourceGiven = inputStorage.TryTakeResource(ressurceToGive);

                    if(resourceGiven == false)
                    {
                        throw new System.Exception("Input storage hasn't recive resource");
                    }
                }
            }
        }
    }
}
