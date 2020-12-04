# How to: Setup Remote Debugging to test Okuma Open API Applications



#### Terms and Definitions





#### Steps to Setup Debugging

Step 1:  Establish a network connection between your development environment and the remote application execution environment. To make things simple and secure, I would recommend a direct wired connection (with crossover ethernet cable if required) or use an Ethernet hub to connect the two machines on the same local network.

Step 2: Boot the Okuma OSP system (NC-Master or actual Machine) in <sup>*1</sup>Windows Only Mode, Open the Control Panel and go to 'User Accounts' and then select "Manage another account". Then Create a new account. Use the same user name and password as your development environment PC. 

Step 3: Create a shared folder or drive on the Okuma Machine or Simulator and share it with 







#### Notes

*1 : Windows Only Mode - To enter "Windows Only Mode" (where the OSP system does not start) the method varies slightly depending on the control model. In case of P200 or P300 press the Escape key repeatedly once the machine is powered ON and the Windows operating system boots. In case of P300A press the Left Shift key repeatedly. The timing you are looking for is immediately after Windows starts and just before / just as the OSP system begins to load.

On the machine control panel, the 'Esc' key looks like this: ![Escape](media/Escape.png)

