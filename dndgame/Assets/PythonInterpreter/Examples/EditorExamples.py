#Examples of code that can be ran from the Python Interpreter plugin
#It is recommended that you run these examples from MonoDevelop
#Select an example and press F3 to run.
#see the README for more info

#Example 1 : create many GameObjects
for i in xrange(10):
	s = Unity.GameObject.CreatePrimitive(Unity.PrimitiveType.Sphere)
	s.transform.position = Unity.Vector3(i, i+1, i*2)
	s.name = 'PySphere' + str(i)

#Example 2 : find out about the scene
from UnityEngine import *
for obj in GameObject.FindSceneObjectsOfType(Transform):
	print obj.name,'at',obj.position
	
