import clr

#TODO: Change path to location of dll
clr.AddReferenceToFileAndPath('E:\\IronPythonScripting\\Okuma.CMDATAPI.dll')
import Okuma.CMDATAPI.DataAPI as datapi

clMachine = datapi.CMachine()
clMachine.Init()

vars = datapi.CVariables()
for i in range(1,10):
    print("Var {0} = {1}".format(i,vars.GetCommonVariableValue(i)))