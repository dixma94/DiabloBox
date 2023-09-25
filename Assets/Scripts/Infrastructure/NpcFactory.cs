
using UnityEngine;
using Zenject;

public class NpcFactory
{
    private const string NpcWizard = "NPC_Wizard";
    private const string NpcSmith = "NPC_Smith";
    private Object _WizardNpcPrefab;
    private Object _SmithNpcPrefab;
    private readonly DiContainer container;

    public NpcFactory(DiContainer container)
    {
        this.container = container;
    }

    private void QuestEvents_onTalkWithNPCDone()
    {
        Debug.Log("sdasd");
    }

    public void Load()
    {
        _WizardNpcPrefab = Resources.Load(NpcWizard);
        _SmithNpcPrefab = Resources.Load(NpcSmith);

    }

    public NPC Create(NPCType nPCType, Vector3 at)
    {
        switch (nPCType)
        {
            case NPCType.Wizard:
                return container.InstantiatePrefab(_WizardNpcPrefab, at, Quaternion.identity, null).GetComponent<NPC>();
            case NPCType.Smith:
                return container.InstantiatePrefab(_SmithNpcPrefab, at, Quaternion.identity, null).GetComponent<NPC>();
            default:
                return null;
        }
    }
}



