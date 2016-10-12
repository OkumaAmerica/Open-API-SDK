import clr
import sys
sys.path.append(r'c:\windows\assembly')
clr.AddReference('Okuma.CMDATAPI')
import Okuma.CMDATAPI.DataAPI as datapi
datapi.CMachine()
_.Init()
vars = datapi.CVariables()
for i in range(1,20):
  print("Var {0} = {1}".format(i,vars.GetCommonVariableValue(i)))
vars.SetCommonVariableValue(5,555)