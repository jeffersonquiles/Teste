using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marfrig.Integration.Test
{
    public partial class Main : Form
    {
        #region --- Proxy ---
        private static IntegrationService.IntegrationServiceClient integrationProxy;
        private static AuthService.AuthServiceClient authProxy;

        private static AuthService.AuthServiceClient AuthProxy
        {
            get
            {
                if (authProxy == null)
                    authProxy = new AuthService.AuthServiceClient();
                else if (authProxy.State == System.ServiceModel.CommunicationState.Closed
                    || authProxy.State == System.ServiceModel.CommunicationState.Closing
                    || authProxy.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    authProxy.Abort();
                    authProxy = new AuthService.AuthServiceClient();
                }
                return authProxy;
            }
        }

        private void AuthService_Faulted(object sender, EventArgs e)
        {
            ((ICommunicationObject)sender).Abort();
            if (sender is AuthService.AuthService)
            {
                sender = AuthProxy.ChannelFactory.CreateChannel();
            }
        }

        private static IntegrationService.IntegrationServiceClient IntegrationProxy
        {
            get
            {
                if (integrationProxy == null)
                    integrationProxy = new IntegrationService.IntegrationServiceClient();
                else if (integrationProxy.State == System.ServiceModel.CommunicationState.Closed
                    || integrationProxy.State == System.ServiceModel.CommunicationState.Closing
                    || integrationProxy.State == System.ServiceModel.CommunicationState.Faulted)
                {
                    integrationProxy.Abort();
                    integrationProxy = new IntegrationService.IntegrationServiceClient();
                }
                return integrationProxy;
            }
        }

        private void IntegrationService_Faulted(object sender, EventArgs e)
        {
            ((ICommunicationObject)sender).Abort();
            if (sender is IntegrationService.IntegrationService)
            {
                sender = IntegrationProxy.ChannelFactory.CreateChannel();
            }
        }

        #endregion

        public Main()
        {
            InitializeComponent();

            ((ICommunicationObject)AuthProxy).Faulted += new EventHandler(AuthService_Faulted);
            ((ICommunicationObject)IntegrationProxy).Faulted += new EventHandler(IntegrationService_Faulted);
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                IntegrationProxy.ReceiveOrderTracking(new IntegrationService.OrderTrackingRequest() { });

            }
            catch (FaultException<IntegrationService.ValidationExceptionFault> ex)
            {
            }

            var AuthResult = AuthProxy.Authenticate(new AuthService.AuthenticateRequest()
                                                {
                                                    Username = "Kelvin",
                                                    Password = "123456",
                                                    IPAddress = "127.0.0.1" // IP Fixo, a necessidade.
                                                });
            
        }


    }
}
