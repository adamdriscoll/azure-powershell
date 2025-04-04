﻿// ----------------------------------------------------------------------------------
// 
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Commands.RecoveryServices.SiteRecovery.Properties;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.RecoveryServices.SiteRecovery
{
    /// <summary>
    ///     Sets recovery properties such as target network and virtual machine size for the specified replication protected item.
    /// </summary>
    [Cmdlet("Set", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "RecoveryServicesAsrReplicationProtectedItem", DefaultParameterSetName = ASRParameterSets.ByObject, SupportsShouldProcess = true)]
    [Alias("Set-ASRReplicationProtectedItem")]
    [OutputType(typeof(ASRJob))]
    public class SetAzureRmRecoveryServicesAsrReplicationProtectedItem : SiteRecoveryCmdletBase
    {
        /// <summary>
        ///     Gets or sets the input object to the cmdlet: The ASR replication protected item object corresponding to the replication protected item to update.
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        [Alias("ReplicationProtectedItem")]
        public ASRReplicationProtectedItem InputObject { get; set; }

        /// <summary>
        ///     Gets or sets the name of the recovery virtual machine that will be created on failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the recovery virtual machine size.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string Size { get; set; }

        /// <summary>
        ///     Gets or sets the NIC of the virtual machine for which this cmdlet sets the recovery network property.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string UpdateNic { get; set; }

        /// <summary>
        ///     Gets or sets the ID of the Azure virtual network to which the protected item should be failed over.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNetworkId { get; set; }

        /// <summary>
        ///     Gets or sets the selected source nic Id (Nic reduction).
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string PrimaryNic { get; set; }

        /// <summary>
        /// Gets or sets resource ID of the recovery cloud service to failover this virtual machine to.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryCloudServiceId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the subnet on the recovery Azure virtual network to which
        ///     this NIC of the protected item should be connected to on failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the static IP address that should be assigned to primary NIC on recovery.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNicStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the test subnet name.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string TestNicSubnetName { get; set; }

        /// <summary>
        ///     Gets or sets the test static IP address.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string TestNicStaticIPAddress { get; set; }

        /// <summary>
        ///     Gets or sets the network interface card (NIC) properties set by user or set by default.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NotSelected,
            Constants.SelectedByUser)]
        public string NicSelectionType { get; set; }

        /// <summary>
        ///     Gets or sets i=ID of the Azure resource group in the recovery region in which 
        ///     the protected item will be recovered on failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryResourceGroupId { get; set; }

        /// <summary>
        ///     Gets or sets LicenseType for
        ///     HUB https://azure.microsoft.com/en-in/pricing/hybrid-use-benefit/
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NoLicenseType,
            Constants.LicenseTypeWindowsServer)]
        public string LicenseType { get; set; }

        /// <summary>
        ///     Gets or sets the availability set for replication protected item after failover.
        /// </summary>
        [Parameter]
        public string RecoveryAvailabilitySet { get; set; }

        /// <summary>
        /// Gets or sets the SQL Server license type to the machine to in the event of a failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.NoLicenseTypeSql,
            Constants.LicenseTypePAYG,
            Constants.LicenseTypeAHUB)]
        public string SqlServerLicenseType { get; set; }

        /// <summary>
        /// Gets or sets target VM tags.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public IDictionary<string, string> RecoveryVmTag { get; set; }

        /// <summary>
        /// Gets or sets the tags for the disks.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public IDictionary<string, string> DiskTag { get; set; }

        /// <summary>
        /// Gets or sets the tags for the target NICs.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public IDictionary<string, string> RecoveryNicTag { get; set; }

        /// <summary>
        ///     Gets or sets the resource ID of the availability zone to failover this virtual machine to.
        /// </summary>
        [Parameter]
        public string RecoveryAvailabilityZone { get; set; }

        /// <summary>
        ///     Gets or sets the proximity placement group Id for replication protected item after failover.
        /// </summary>
        [Parameter]
        public string RecoveryProximityPlacementGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the virtual machine scale set Id for replication protected item after failover.
        /// </summary>
        [Parameter]
        public string RecoveryVirtualMachineScaleSetId { get; set; }

        /// <summary>
        ///     Gets or sets the capacity reservation group Id for replication protected item after failover.
        /// </summary>
        [Parameter]
        public string RecoveryCapacityReservationGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the availability set for replication protected item after failover.
        /// </summary>
        [Parameter]
        public SwitchParameter EnableAcceleratedNetworkingOnRecovery { get; set; }

        /// <summary>
        ///     Gets or sets the recovery boot diagnostics storageAccountId for replication protected item after failover.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryBootDiagStorageAccountId { get; set; }

        /// <summary>
        ///    Gets or sets  the list of virtual machine disks to replicated 
        ///    and the cache storage account and recovery storage account to be used to replicate the disk.
        /// </summary>
        [ValidateNotNullOrEmpty]
        [Parameter]
        public ASRAzuretoAzureDiskReplicationConfig[] AzureToAzureUpdateReplicationConfiguration { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionVaultId.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DiskEncryptionVaultId { get; set; }

        /// <summary>
        /// Gets or sets DiskEncryptionSecretUrl.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string DiskEncryptionSecretUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionKeyUrl.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionKeyUrl { get; set; }

        /// <summary>
        /// Gets or sets KeyEncryptionVaultId.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string KeyEncryptionVaultId { get; set; }

        /// <summary>
        ///     Gets or sets if the Azure virtual machine that is created on failover should use managed disks.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        [ValidateSet(
            Constants.True,
            Constants.False)]
        public string UseManagedDisk { get; set; }

        /// <summary>
        /// Gets or sets the disk Id to disk encryption set map.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public IDictionary<string, string> DiskIdToDiskEncryptionSetMap { get; set; }

        /// <summary>
        ///     Gets or sets the id of the public IP address resource associated with the NIC.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryPublicIPAddressId { get; set; }

        /// <summary>
        ///     Gets or sets the id of the NSG associated with the NIC.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string RecoveryNetworkSecurityGroupId { get; set; }

        /// <summary>
        ///     Gets or sets the target backend address pools for the NIC.
        /// </summary>
        [Parameter]
        public string[] RecoveryLBBackendAddressPoolId { get; set; }

        /// <summary>
        ///     Gets or sets the name of the test failover VM.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string TfoAzureVMName { get; set; }

        /// <summary>
        ///     Gets or sets the test failover and failover NIC configuration details.
        /// </summary>
        [Parameter]
        [ValidateNotNull]
        public ASRVMNicConfig[] ASRVMNicConfiguration { get; set; }

        /// <summary>
        ///     Gets or sets the test network ARM Id.
        /// </summary>
        [Parameter]
        [ValidateNotNullOrEmpty]
        public string TestNetworkId { get; set; }

        /// <summary>
        ///     ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            if (this.ShouldProcess(
                this.InputObject.FriendlyName,
                VerbsCommon.Set))
            {
                var replicationProtectedItemResponse = this.RecoveryServicesClient
                    .GetAzureSiteRecoveryReplicationProtectedItem(
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationFabrics),
                        Utilities.GetValueFromArmId(
                            this.InputObject.ID,
                            ARMResourceTypeConstants.ReplicationProtectionContainers),
                        this.InputObject.Name);

                var provider = replicationProtectedItemResponse.Properties.ProviderSpecificDetails;

                // Check for Replication Provider type HyperVReplicaAzure/InMageAzureV2/A2A/InMageRcm
                if (!(provider is HyperVReplicaAzureReplicationDetails) &&
                    !(provider is InMageAzureV2ReplicationDetails) &&
                    !(provider is A2AReplicationDetails) &&
                    !(provider is InMageRcmReplicationDetails))
                {
                    this.WriteWarning(
                        Resources.UnsupportedReplicationProvidedForUpdateVmProperties);
                    return;
                }

                // Check for at least one option
                if (string.IsNullOrEmpty(this.Name) &&
                    string.IsNullOrEmpty(this.Size) &&
                    string.IsNullOrEmpty(this.UpdateNic) &&
                    string.IsNullOrEmpty(this.RecoveryNetworkId) &&
                    string.IsNullOrEmpty(this.TestNetworkId) &&
                    string.IsNullOrEmpty(this.PrimaryNic) &&
                    this.UseManagedDisk == null &&
                    this.IsParameterBound(c => c.RecoveryAvailabilitySet) &&
                    this.IsParameterBound(c => c.RecoveryAvailabilityZone) &&
                    this.IsParameterBound(c => c.RecoveryProximityPlacementGroupId) &&
                    this.IsParameterBound(c => c.RecoveryVirtualMachineScaleSetId) &&
                    this.IsParameterBound(c => c.RecoveryCapacityReservationGroupId) &&
                    string.IsNullOrEmpty(this.RecoveryCloudServiceId) &&
                    string.IsNullOrEmpty(this.RecoveryResourceGroupId) &&
                    string.IsNullOrEmpty(this.LicenseType) &&
                    string.IsNullOrEmpty(this.RecoveryBootDiagStorageAccountId) &&
                    this.AzureToAzureUpdateReplicationConfiguration == null)
                {
                    this.WriteWarning(Resources.ArgumentsMissingForUpdateVmProperties);
                    return;
                }

                // Both primary & recovery inputs should be present
                if (this.ASRVMNicConfiguration == null &&
                    (string.IsNullOrEmpty(this.UpdateNic) ^
                    string.IsNullOrEmpty(this.RecoveryNetworkId)))
                {
                    this.WriteWarning(Resources.NetworkArgumentsMissingForUpdateVmProperties);
                    return;
                }

                // NSG, LB and PIP only for A2A provider.
                if ((!string.IsNullOrEmpty(RecoveryNetworkSecurityGroupId) ||
                    !string.IsNullOrEmpty(RecoveryPublicIPAddressId) ||
                    RecoveryLBBackendAddressPoolId != null &&
                    RecoveryLBBackendAddressPoolId.Length > 0) &&
                    !(provider is A2AReplicationDetails))
                {
                    this.WriteWarning(
                        Resources.UnsupportedReplicationProvidedForNetworkingResources);
                    return;
                }

                if (this.ASRVMNicConfiguration != null &&
                    !(provider is A2AReplicationDetails))
                {
                    this.WriteWarning(Resources.UnsupportedReplicationProvidedForASRVMNicConfig);
                    return;
                }

                if (this.ASRVMNicConfiguration != null &&
                    !string.IsNullOrEmpty(this.UpdateNic))
                {
                    this.WriteWarning(Resources.ASRVMNicsAndUpdateNicNotAllowed);
                    return;
                }

                var vmName = this.Name;
                var vmSize = this.Size;
                var vmRecoveryNetworkId = this.RecoveryNetworkId;
                var vmTestNetworkId = this.TestNetworkId;
                var licenseType = this.LicenseType;
                var recoveryResourceGroupId = this.RecoveryResourceGroupId;
                var recoveryCloudServiceId = this.RecoveryCloudServiceId;
                var useManagedDisk = this.UseManagedDisk;
                var availabilitySetId = this.RecoveryAvailabilitySet;
                var proximityPlacementGroupId = this.RecoveryProximityPlacementGroupId;
                var virtualMachineScaleSetId = this.RecoveryVirtualMachineScaleSetId;
                var capacityReservationGroupId = this.RecoveryCapacityReservationGroupId;
                var availabilityZone = this.RecoveryAvailabilityZone;
                var primaryNic = this.PrimaryNic;
                var diskIdToDiskEncryptionMap = this.DiskIdToDiskEncryptionSetMap;
                var sqlServerLicenseType = this.SqlServerLicenseType;
                var recoveryVmTag = this.RecoveryVmTag;
                var recoveryNicTag = this.RecoveryNicTag;
                var diskTag = this.DiskTag;
                var tfoNetworkId = string.Empty;
                var vMNicInputDetailsList = new List<VMNicInputDetails>();
                var providerSpecificInput = new UpdateReplicationProtectedItemProviderInput();

                if (provider is HyperVReplicaAzureReplicationDetails)
                {
                    var providerSpecificDetails =
                        (HyperVReplicaAzureReplicationDetails)replicationProtectedItemResponse
                            .Properties.ProviderSpecificDetails;

                    if (string.IsNullOrEmpty(this.Name))
                    {
                        vmName = providerSpecificDetails.RecoveryAzureVMName;
                    }

                    if (string.IsNullOrEmpty(this.Size))
                    {
                        vmSize = providerSpecificDetails.RecoveryAzureVMSize;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryNetworkId))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails
                            .SelectedRecoveryAzureNetworkId;
                    }

                    if (string.IsNullOrEmpty(this.LicenseType))
                    {
                        licenseType = providerSpecificDetails.LicenseType;
                    }

                    if (string.IsNullOrEmpty(this.SqlServerLicenseType))
                    {
                        sqlServerLicenseType = providerSpecificDetails.SqlServerLicenseType;
                    }

                    availabilitySetId = this.IsParameterBound(c => c.RecoveryAvailabilitySet)
                        ? this.RecoveryAvailabilitySet
                        : providerSpecificDetails.RecoveryAvailabilitySetId;

                    availabilityZone = this.IsParameterBound(c => c.RecoveryAvailabilityZone)
                        ? this.RecoveryAvailabilityZone
                        : providerSpecificDetails.TargetAvailabilityZone;

                    proximityPlacementGroupId = this.IsParameterBound(c => c.RecoveryProximityPlacementGroupId)
                        ? this.RecoveryProximityPlacementGroupId
                        : providerSpecificDetails.TargetProximityPlacementGroupId;

                    if (string.IsNullOrEmpty(this.UseManagedDisk))
                    {
                        useManagedDisk = providerSpecificDetails.UseManagedDisks;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryResourceGroupId))
                    {
                        recoveryResourceGroupId =
                            providerSpecificDetails.RecoveryAzureResourceGroupId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.PrimaryNic)))
                    {
                        primaryNic = providerSpecificDetails.SelectedSourceNicId;
                    }

                    if (this.DiskIdToDiskEncryptionSetMap == null ||
                        this.DiskIdToDiskEncryptionSetMap.Count == 0)
                    {
                        diskIdToDiskEncryptionMap = providerSpecificDetails.AzureVMDiskDetails.
                            ToDictionary(x => x.DiskId, x => x.DiskEncryptionSetId);
                    }

                    if (this.RecoveryVmTag == null)
                    {
                        recoveryVmTag = providerSpecificDetails.TargetVMTags;
                    }

                    if (this.RecoveryNicTag == null)
                    {
                        recoveryNicTag = providerSpecificDetails.TargetNicTags;
                    }

                    if (this.DiskTag == null)
                    {
                        diskTag = providerSpecificDetails.TargetManagedDiskTags;
                    }
                    else if (useManagedDisk == Constants.False)
                    {
                        throw new PSArgumentException(
                                  string.Format(
                                      Resources.DiskTagCannotBeSet,
                                      diskTag,
                                      useManagedDisk));
                    }

                    string deploymentType = Constants.ResourceManager;

                    if (!string.IsNullOrEmpty(providerSpecificDetails.RecoveryAzureStorageAccount))
                    {
                        deploymentType = Utilities.GetValueFromArmId(
                            providerSpecificDetails.RecoveryAzureStorageAccount,
                            ARMResourceTypeConstants.Providers);
                    }

                    if (!string.IsNullOrEmpty(deploymentType) && deploymentType.ToLower()
                            .Contains(Constants.Classic.ToLower()))
                    {
                        providerSpecificInput =
                            new HyperVReplicaAzureUpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = recoveryResourceGroupId,
                                RecoveryAzureV2ResourceGroupId = null
                            };
                    }
                    else
                    {
                        providerSpecificInput =
                            new HyperVReplicaAzureUpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = null,
                                RecoveryAzureV2ResourceGroupId = recoveryResourceGroupId,
                                UseManagedDisks = useManagedDisk,
                                DiskIdToDiskEncryptionMap = this.DiskIdToDiskEncryptionSetMap,
                                TargetAvailabilityZone = availabilityZone,
                                TargetProximityPlacementGroupId = proximityPlacementGroupId,
                                SqlServerLicenseType = sqlServerLicenseType,
                                TargetVMTags = recoveryVmTag,
                                TargetManagedDiskTags = diskTag,
                                TargetNicTags = recoveryNicTag
                            };
                    }

                    vMNicInputDetailsList = getNicListToUpdate(providerSpecificDetails.VMNics);
                }
                else if (provider is InMageAzureV2ReplicationDetails)
                {
                    var providerSpecificDetails =
                        (InMageAzureV2ReplicationDetails)replicationProtectedItemResponse.Properties.ProviderSpecificDetails;

                    if (string.IsNullOrEmpty(this.Name))
                    {
                        vmName = providerSpecificDetails.RecoveryAzureVMName;
                    }

                    if (string.IsNullOrEmpty(this.Size))
                    {
                        vmSize = providerSpecificDetails.RecoveryAzureVMSize;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryNetworkId))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails.SelectedRecoveryAzureNetworkId;
                    }

                    if (string.IsNullOrEmpty(this.LicenseType))
                    {
                        licenseType = providerSpecificDetails.LicenseType;
                    }

                    if (string.IsNullOrEmpty(this.SqlServerLicenseType))
                    {
                        sqlServerLicenseType = providerSpecificDetails.SqlServerLicenseType;
                    }

                    availabilitySetId = this.IsParameterBound(c => c.RecoveryAvailabilitySet)
                        ? this.RecoveryAvailabilitySet : providerSpecificDetails.RecoveryAvailabilitySetId;

                    availabilityZone = this.IsParameterBound(c => c.RecoveryAvailabilityZone)
                        ? this.RecoveryAvailabilityZone : providerSpecificDetails.TargetAvailabilityZone;

                    proximityPlacementGroupId = this.IsParameterBound(c => c.RecoveryProximityPlacementGroupId)
                        ? this.RecoveryProximityPlacementGroupId : providerSpecificDetails.TargetProximityPlacementGroupId;

                    if (string.IsNullOrEmpty(this.UseManagedDisk))
                    {
                        useManagedDisk = providerSpecificDetails.UseManagedDisks;
                    }

                    if (string.IsNullOrEmpty(this.RecoveryResourceGroupId))
                    {
                        recoveryResourceGroupId = providerSpecificDetails.RecoveryAzureResourceGroupId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.PrimaryNic)))
                    {
                        primaryNic = providerSpecificDetails.SelectedSourceNicId;
                    }

                    if (this.RecoveryVmTag == null)
                    {
                        recoveryVmTag = providerSpecificDetails.TargetVMTags;
                    }

                    if (this.RecoveryNicTag == null)
                    {
                        recoveryNicTag = providerSpecificDetails.TargetNicTags;
                    }

                    if (this.DiskTag == null)
                    {
                        diskTag = providerSpecificDetails.TargetManagedDiskTags;
                    }
                    else if (useManagedDisk == Constants.False)
                    {
                        throw new PSArgumentException(
                                  string.Format(
                                      Resources.DiskTagCannotBeSet,
                                      diskTag,
                                      useManagedDisk));
                    }

                    var deploymentType = Utilities.GetValueFromArmId(
                        providerSpecificDetails.TargetVMId,
                        ARMResourceTypeConstants.Providers);
                    if (deploymentType.ToLower()
                        .Contains(Constants.ClassicCompute.ToLower()))
                    {
                        providerSpecificInput =
                            new InMageAzureV2UpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = recoveryResourceGroupId,
                                RecoveryAzureV2ResourceGroupId = null
                            };
                    }
                    else
                    {
                        providerSpecificInput =
                            new InMageAzureV2UpdateReplicationProtectedItemInput
                            {
                                RecoveryAzureV1ResourceGroupId = null,
                                RecoveryAzureV2ResourceGroupId = recoveryResourceGroupId,
                                UseManagedDisks = useManagedDisk,
                                TargetAvailabilityZone = availabilityZone,
                                TargetProximityPlacementGroupId = proximityPlacementGroupId,
                                SqlServerLicenseType = sqlServerLicenseType,
                                TargetVMTags = recoveryVmTag,
                                TargetNicTags = recoveryNicTag,
                                TargetManagedDiskTags = diskTag
                            };
                    }
                    vMNicInputDetailsList = getNicListToUpdate(providerSpecificDetails.VMNics);
                }
                else if (provider is A2AReplicationDetails)
                {
                    A2AReplicationDetails providerSpecificDetails = (A2AReplicationDetails)replicationProtectedItemResponse.Properties.ProviderSpecificDetails;

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryResourceGroupId)))
                    {
                        recoveryResourceGroupId =
                            providerSpecificDetails.RecoveryAzureResourceGroupId;
                    }

                    availabilitySetId = this.IsParameterBound(c => c.RecoveryAvailabilitySet)
                        ? this.RecoveryAvailabilitySet
                        : providerSpecificDetails.RecoveryAvailabilitySet;

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                             Utilities.GetMemberName(() => this.RecoveryNetworkId)))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails.SelectedRecoveryAzureNetworkId;
                    }

                    proximityPlacementGroupId = this.IsParameterBound(c => c.RecoveryProximityPlacementGroupId)
                       ? this.RecoveryProximityPlacementGroupId
                       : providerSpecificDetails.RecoveryProximityPlacementGroupId;

                    virtualMachineScaleSetId = this.IsParameterBound(c => c.RecoveryVirtualMachineScaleSetId)
                        ? this.RecoveryVirtualMachineScaleSetId
                        : providerSpecificDetails.RecoveryVirtualMachineScaleSetId;

                    capacityReservationGroupId = this.IsParameterBound(c => c.RecoveryCapacityReservationGroupId)
                        ? this.RecoveryCapacityReservationGroupId
                        : providerSpecificDetails.RecoveryCapacityReservationGroupId;

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryCloudServiceId)))
                    {
                        recoveryCloudServiceId =
                            providerSpecificDetails.RecoveryCloudService;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryBootDiagStorageAccountId)))
                    {
                        this.RecoveryBootDiagStorageAccountId = providerSpecificDetails.RecoveryBootDiagStorageAccountId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TfoAzureVMName)))
                    {
                        this.TfoAzureVMName = providerSpecificDetails.TfoAzureVMName;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.Name)))
                    {
                        vmName = providerSpecificDetails.RecoveryAzureVMName;
                    }

                    List<A2AVmManagedDiskUpdateDetails> managedDiskUpdateDetails = null;

                    // ManagedDisk case
                    if (this.AzureToAzureUpdateReplicationConfiguration != null && this.AzureToAzureUpdateReplicationConfiguration[0].IsManagedDisk)
                    {
                        managedDiskUpdateDetails = new List<A2AVmManagedDiskUpdateDetails>();
                        foreach (var managedDisk in this.AzureToAzureUpdateReplicationConfiguration)
                        {
                            managedDiskUpdateDetails.Add(
                                new A2AVmManagedDiskUpdateDetails(
                                    managedDisk.DiskId,
                                    managedDisk.RecoveryTargetDiskAccountType,
                                    managedDisk.RecoveryReplicaDiskAccountType,
                                    failoverDiskName: managedDisk.FailoverDiskName,
                                    tfoDiskName: managedDisk.TfoDiskName,
                                    diskEncryptionInfo: Utilities.A2AEncryptionDetails(
                                        managedDisk.DiskEncryptionSecretUrl,
                                        managedDisk.DiskEncryptionVaultId,
                                        managedDisk.KeyEncryptionKeyUrl,
                                        managedDisk.KeyEncryptionVaultId)));
                        }
                    }

                    providerSpecificInput = new A2AUpdateReplicationProtectedItemInput()
                    {
                        RecoveryCloudServiceId = this.RecoveryCloudServiceId,
                        RecoveryResourceGroupId = this.RecoveryResourceGroupId,
                        RecoveryProximityPlacementGroupId = this.RecoveryProximityPlacementGroupId,
                        RecoveryVirtualMachineScaleSetId = this.RecoveryVirtualMachineScaleSetId,
                        RecoveryCapacityReservationGroupId = this.RecoveryCapacityReservationGroupId,
                        RecoveryBootDiagStorageAccountId = this.RecoveryBootDiagStorageAccountId,
                        ManagedDiskUpdateDetails = managedDiskUpdateDetails,
                        TfoAzureVMName = this.TfoAzureVMName,
                        DiskEncryptionInfo = Utilities.A2AEncryptionDetails(
                            this.DiskEncryptionSecretUrl,
                            this.DiskEncryptionVaultId,
                            this.KeyEncryptionKeyUrl,
                            this.KeyEncryptionVaultId)
                    };

                    if (this.ASRVMNicConfiguration != null &&
                        this.ASRVMNicConfiguration.Count() > 0)
                    {
                        var recoveryNetworkIds = new HashSet<string>();
                        var tfoNetworkIds = new HashSet<string>();

                        this.ASRVMNicConfiguration.ForEach(
                            nic =>
                            {
                                if (!string.IsNullOrEmpty(nic.RecoveryVMNetworkId))
                                {
                                    recoveryNetworkIds.Add(nic.RecoveryVMNetworkId);
                                }
                            });
                        this.ASRVMNicConfiguration.ForEach(
                            nic =>
                            {
                                if (!string.IsNullOrEmpty(nic.TfoVMNetworkId))
                                {
                                    tfoNetworkIds.Add(nic.TfoVMNetworkId);
                                }
                            });

                        if (recoveryNetworkIds.Count() > 1)
                        {
                            this.WriteWarning(Resources.RecoveryNetworkIdConflictInASRVMNics);
                            return;
                        }

                        if (tfoNetworkIds.Count() > 1)
                        {
                            this.WriteWarning(Resources.TfoNetworkIdConflictInASRVMNics);
                            return;
                        }

                        if (!string.IsNullOrEmpty(this.RecoveryNetworkId) &&
                            !string.IsNullOrEmpty(recoveryNetworkIds.FirstOrDefault()) &&
                            !this.RecoveryNetworkId.Equals(
                                recoveryNetworkIds.First(), StringComparison.OrdinalIgnoreCase))
                        {
                            this.WriteWarning(Resources.RecoveryNetworkInformationMismatch);
                            return;
                        }

                        if (!string.IsNullOrEmpty(recoveryNetworkIds.FirstOrDefault()))
                        {
                            vmRecoveryNetworkId = recoveryNetworkIds.First();
                        }

                        tfoNetworkId = tfoNetworkIds.FirstOrDefault();
                    }

                    if (string.IsNullOrEmpty(tfoNetworkId))
                    {
                        tfoNetworkId = providerSpecificDetails.SelectedTfoAzureNetworkId;
                    }

                    vMNicInputDetailsList = getNicListToUpdate(providerSpecificDetails.VMNics);
                }
                else if (provider is InMageRcmReplicationDetails)
                {
                    var providerSpecificDetails =
                        (InMageRcmReplicationDetails)replicationProtectedItemResponse.Properties.ProviderSpecificDetails;

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.Name)))
                    {
                        vmName = providerSpecificDetails.TargetVMName;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.Size)))
                    {
                        vmSize = providerSpecificDetails.TargetVMSize;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryNetworkId)))
                    {
                        vmRecoveryNetworkId = providerSpecificDetails.TargetNetworkId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.TestNetworkId)))
                    {
                        vmTestNetworkId = providerSpecificDetails.TestNetworkId;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.LicenseType)))
                    {
                        licenseType = providerSpecificDetails.LicenseType;
                    }

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                        Utilities.GetMemberName(() => this.RecoveryBootDiagStorageAccountId)))
                    {
                        this.RecoveryBootDiagStorageAccountId = providerSpecificDetails.TargetBootDiagnosticsStorageAccountId;
                    }

                    proximityPlacementGroupId = this.IsParameterBound(c => c.RecoveryProximityPlacementGroupId)
                       ? this.RecoveryProximityPlacementGroupId
                       : providerSpecificDetails.TargetProximityPlacementGroupId;

                    availabilitySetId = this.IsParameterBound(c => c.RecoveryAvailabilitySet)
                        ? this.RecoveryAvailabilitySet : providerSpecificDetails.TargetAvailabilitySetId;

                    availabilityZone = this.IsParameterBound(c => c.RecoveryAvailabilityZone)
                        ? this.RecoveryAvailabilityZone : providerSpecificDetails.TargetAvailabilityZone;

                    if (!this.MyInvocation.BoundParameters.ContainsKey(
                            Utilities.GetMemberName(() => this.RecoveryResourceGroupId)))
                    {
                        recoveryResourceGroupId = providerSpecificDetails.TargetResourceGroupId;
                    }

                    providerSpecificInput = new InMageRcmUpdateReplicationProtectedItemInput
                    {
                        TargetVMName = vmName,
                        TargetVMSize = vmSize,
                        TargetResourceGroupId = recoveryResourceGroupId,
                        TargetAvailabilitySetId = availabilitySetId,
                        TargetAvailabilityZone = availabilityZone,
                        TargetProximityPlacementGroupId = proximityPlacementGroupId,
                        TargetBootDiagnosticsStorageAccountId = RecoveryBootDiagStorageAccountId,
                        LicenseType = this.LicenseType,
                        TargetNetworkId = vmRecoveryNetworkId,
                        TestNetworkId = vmTestNetworkId,
                        VMNics = GetInMageRcmNicListToUpdate(providerSpecificDetails.VMNics)
                    };
                }

                var updateReplicationProtectedItemInputProperties =
                    new UpdateReplicationProtectedItemInputProperties
                    {
                        RecoveryAzureVMName = vmName,
                        RecoveryAzureVMSize = vmSize,
                        SelectedRecoveryAzureNetworkId = vmRecoveryNetworkId,
                        SelectedTfoAzureNetworkId = tfoNetworkId,
                        SelectedSourceNicId = primaryNic,
                        VMNics = vMNicInputDetailsList,
                        LicenseType =
                            licenseType ==
                            Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                .NoLicenseType.ToString()
                                ? Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                    .NoLicenseType
                                : Management.RecoveryServices.SiteRecovery.Models.LicenseType
                                    .WindowsServer,
                        RecoveryAvailabilitySetId = availabilitySetId,
                        ProviderSpecificDetails = providerSpecificInput
                    };

                if (provider is HyperVReplicaAzureReplicationDetails || provider is InMageAzureV2ReplicationDetails)
                {
                    updateReplicationProtectedItemInputProperties.SelectedSourceNicId = primaryNic;
                }
                var input = new UpdateReplicationProtectedItemInput
                {
                    Properties = updateReplicationProtectedItemInputProperties
                };

                var response = this.RecoveryServicesClient.UpdateVmProperties(
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        ARMResourceTypeConstants.ReplicationFabrics),
                    Utilities.GetValueFromArmId(
                        this.InputObject.ID,
                        ARMResourceTypeConstants.ReplicationProtectionContainers),
                    this.InputObject.Name,
                    input);

                var jobResponse = this.RecoveryServicesClient.GetAzureSiteRecoveryJobDetails(
                    PSRecoveryServicesClient.GetJobIdFromReponseLocation(response.Location));

                this.WriteObject(new ASRJob(jobResponse));
            }
        }

        private List<VMNicInputDetails> getNicListToUpdate(IList<VMNicDetails> vmNicList)
        {
            var vMNicInputDetailsList = new List<VMNicInputDetails>();
            // Weather to track NIC found to be updated. IF primary NIC is not or empty no need to update.
            var nicFoundToBeUpdated = string.IsNullOrEmpty(this.UpdateNic);

            if (vmNicList != null)
            {
                // If VM NICs list provided along with UpdateNic then only the NICs list is
                // honored.
                if (this.ASRVMNicConfiguration != null && this.ASRVMNicConfiguration.Count() > 0)
                {
                    var vmNicIds = vmNicList.Select(nic => nic.NicId);

                    foreach (var nic in this.ASRVMNicConfiguration)
                    {
                        if (!vmNicIds.Contains(nic.NicId, StringComparer.OrdinalIgnoreCase))
                        {
                            throw new PSInvalidOperationException(
                                Resources.NicNotFoundInVMForUpdateVmProperties);
                        }

                        var vMNicInputDetails = new VMNicInputDetails();

                        vMNicInputDetails.NicId = nic.NicId;
                        vMNicInputDetails.RecoveryNicName = nic.RecoveryNicName;
                        vMNicInputDetails.RecoveryNicResourceGroupName = nic.RecoveryNicResourceGroupName;
                        vMNicInputDetails.ReuseExistingNic = nic.ReuseExistingNic;
                        vMNicInputDetails.EnableAcceleratedNetworkingOnRecovery =
                            nic.EnableAcceleratedNetworkingOnRecovery;
                        vMNicInputDetails.RecoveryNetworkSecurityGroupId =
                            nic.RecoveryNetworkSecurityGroupId;
                        vMNicInputDetails.IPConfigs = nic.IPConfigs?.Select(ip =>
                            new IPConfigInputDetails()
                            {
                                IPConfigName = ip.IPConfigName,
                                IsPrimary = ip.IsPrimary,
                                IsSeletedForFailover = ip.IsSeletedForFailover,
                                RecoverySubnetName = ip.RecoverySubnetName,
                                RecoveryStaticIPAddress = ip.RecoveryStaticIPAddress,
                                RecoveryPublicIPAddressId = ip.RecoveryPublicIPAddressId,
                                RecoveryLbBackendAddressPoolIds = ip.RecoveryLBBackendAddressPoolIds,
                                TfoSubnetName = ip.TfoSubnetName,
                                TfoStaticIPAddress = ip.TfoStaticIPAddress,
                                TfoPublicIPAddressId = ip.TfoPublicIPAddressId,
                                TfoLbBackendAddressPoolIds = ip.TfoLBBackendAddressPoolIds
                            }).ToList() ?? null;
                        vMNicInputDetails.TfoNicName = nic.TfoNicName;
                        vMNicInputDetails.TfoNicResourceGroupName = nic.TfoNicResourceGroupName;
                        vMNicInputDetails.TfoReuseExistingNic = nic.TfoReuseExistingNic;
                        vMNicInputDetails.EnableAcceleratedNetworkingOnTfo =
                            nic.EnableAcceleratedNetworkingOnTfo;
                        vMNicInputDetails.TfoNetworkSecurityGroupId =
                            nic.TfoNetworkSecurityGroupId;

                        vMNicInputDetails.SelectionType =
                            string.IsNullOrEmpty(this.NicSelectionType)
                                ? Constants.SelectedByUser : this.NicSelectionType;

                        vMNicInputDetailsList.Add(vMNicInputDetails);
                    }

                    return vMNicInputDetailsList;
                }

                foreach (var nDetails in vmNicList)
                {
                    var vMNicInputDetails = new VMNicInputDetails();
                    if (!string.IsNullOrEmpty(this.UpdateNic)
                        && string.Compare(nDetails.NicId, this.UpdateNic, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        vMNicInputDetails.NicId = this.UpdateNic;

                        var dbIpConfig = nDetails.IPConfigs?[0];
                        var ipConfig = new IPConfigInputDetails()
                        {
                            IPConfigName = dbIpConfig?.Name,
                            IsPrimary = dbIpConfig?.IsPrimary ?? true,
                            IsSeletedForFailover = true,
                            RecoverySubnetName = this.RecoveryNicSubnetName,
                            RecoveryStaticIPAddress = this.RecoveryNicStaticIPAddress,
                            RecoveryPublicIPAddressId = this.RecoveryPublicIPAddressId,
                            RecoveryLbBackendAddressPoolIds = this.RecoveryLBBackendAddressPoolId?.ToList()
                        };
                        vMNicInputDetails.IPConfigs = new List<IPConfigInputDetails>() { ipConfig };
                        vMNicInputDetails.SelectionType =
                            string.IsNullOrEmpty(this.NicSelectionType)
                                ? Constants.SelectedByUser : this.NicSelectionType;
                        vMNicInputDetails.RecoveryNetworkSecurityGroupId =
                            this.RecoveryNetworkSecurityGroupId;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                        // NicId  matched for update
                        nicFoundToBeUpdated = true;

                        if (this.MyInvocation.BoundParameters.ContainsKey(
                           Utilities.GetMemberName(() => this.EnableAcceleratedNetworkingOnRecovery)))
                        {
                            vMNicInputDetails.EnableAcceleratedNetworkingOnRecovery = true;
                        }
                        else
                        {
                            vMNicInputDetails.EnableAcceleratedNetworkingOnRecovery = false;
                        }
                    }
                    else
                    {
                        vMNicInputDetails.NicId = nDetails.NicId;
                        vMNicInputDetails.SelectionType = nDetails.SelectionType;
                        vMNicInputDetails.IPConfigs = nDetails.IPConfigs?.Select(ip =>
                            new IPConfigInputDetails()
                            {
                                IPConfigName = ip.Name,
                                IsPrimary = ip.IsPrimary,
                                IsSeletedForFailover = ip.IsSeletedForFailover,
                                RecoverySubnetName = ip.RecoverySubnetName,
                                RecoveryStaticIPAddress = ip.RecoveryStaticIPAddress,
                                RecoveryPublicIPAddressId = ip.RecoveryPublicIPAddressId,
                                RecoveryLbBackendAddressPoolIds = ip.RecoveryLbBackendAddressPoolIds
                            })?.ToList();
                        vMNicInputDetails.EnableAcceleratedNetworkingOnRecovery = nDetails.EnableAcceleratedNetworkingOnRecovery;
                        vMNicInputDetails.RecoveryNetworkSecurityGroupId =
                            nDetails.RecoveryNetworkSecurityGroupId;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                    }
                }
            }

            if (!nicFoundToBeUpdated)
            {
                throw new PSInvalidOperationException(Resources.NicNotFoundInVMForUpdateVmProperties);
            }
            return vMNicInputDetailsList;
        }

        private List<InMageRcmNicInput> GetInMageRcmNicListToUpdate(IList<InMageRcmNicDetails> vmNicList)
        {
            var vMNicInputDetailsList = new List<InMageRcmNicInput>();
            var nicFoundToBeUpdated = string.IsNullOrEmpty(this.UpdateNic);

            if (vmNicList != null)
            {
                // If VM NICs list provided along with UpdateNic then only the NICs list is
                // honored.
                foreach (var nDetails in vmNicList)
                {
                    var vMNicInputDetails = new InMageRcmNicInput();
                    if (!string.IsNullOrEmpty(this.UpdateNic)
                        && string.Compare(nDetails.NicId, this.UpdateNic, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        vMNicInputDetails.NicId = this.UpdateNic;
                        vMNicInputDetails.TargetSubnetName = this.RecoveryNicSubnetName;
                        vMNicInputDetails.TargetStaticIPAddress = this.RecoveryNicStaticIPAddress;
                        vMNicInputDetails.IsPrimaryNic =
                            (string.Compare(nDetails.NicId, this.PrimaryNic, StringComparison.OrdinalIgnoreCase) == 0)
                            ? Constants.True
                            : Constants.False;
                        vMNicInputDetails.IsSelectedForFailover = string.IsNullOrEmpty(this.NicSelectionType)
                            ? Constants.True 
                            : (this.NicSelectionType.Equals(Constants.SelectedByUser) 
                                ? Constants.True 
                                : Constants.False);
                        vMNicInputDetails.TestSubnetName = this.TestNicSubnetName;
                        vMNicInputDetails.TestStaticIPAddress = this.TestNicStaticIPAddress;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                        
                        // NicId  matched for update.
                        nicFoundToBeUpdated = true;
                    }
                    else
                    {
                        vMNicInputDetails.NicId = nDetails.NicId;
                        vMNicInputDetails.TargetSubnetName = nDetails.TargetSubnetName;
                        vMNicInputDetails.TargetStaticIPAddress = nDetails.TargetIPAddress;
                        vMNicInputDetails.IsPrimaryNic = nDetails.IsPrimaryNic;
                        vMNicInputDetails.IsSelectedForFailover = nDetails.IsSelectedForFailover;
                        vMNicInputDetails.TestSubnetName = nDetails.TestSubnetName;
                        vMNicInputDetails.TestStaticIPAddress = nDetails.TestIPAddress;
                        vMNicInputDetailsList.Add(vMNicInputDetails);
                    }
                }
            }

            if (!nicFoundToBeUpdated)
            {
                throw new PSInvalidOperationException(Resources.NicNotFoundInVMForUpdateVmProperties);
            }
            return vMNicInputDetailsList;
        }

        /*
         * Creating DiskEncryptionInfo for A2A provider.
         */
        private DiskEncryptionInfo A2AEncryptionDetails(ReplicationProviderSpecificSettings provider)
        {
            // Checking if any encryption data is present then the only creating DiskEncryptionInfo.
            if (this.IsParameterBound(c => c.DiskEncryptionSecretUrl) ||
                this.IsParameterBound(c => c.DiskEncryptionVaultId) ||
                this.IsParameterBound(c => c.KeyEncryptionKeyUrl) ||
                this.IsParameterBound(c => c.KeyEncryptionVaultId))
            {
                // Non A2A scenario
                if (!(provider is A2AReplicationDetails))
                {
                    throw new Exception(
                        "DiskEncryptionSecretUrl,DiskEncryptionVaultId,KeyEncryptionKeyUrl,KeyEncryptionVaultId " +
                        "is used for updating Azure to Azure replication");
                }

                DiskEncryptionInfo diskEncryptionInfo = new DiskEncryptionInfo();
                // BEK DATA is present
                if (this.IsParameterBound(c => c.DiskEncryptionSecretUrl) && this.IsParameterBound(c => c.DiskEncryptionVaultId))
                {
                    diskEncryptionInfo.DiskEncryptionKeyInfo = new DiskEncryptionKeyInfo(this.DiskEncryptionSecretUrl, this.DiskEncryptionVaultId);
                    // KEK Data is present in pair.
                    if (this.IsParameterBound(c => c.KeyEncryptionKeyUrl) && this.IsParameterBound(c => c.KeyEncryptionVaultId))
                    {
                        diskEncryptionInfo.KeyEncryptionKeyInfo = new KeyEncryptionKeyInfo(this.KeyEncryptionKeyUrl, this.KeyEncryptionVaultId);
                    }
                }
                else
                {
                    throw new Exception("Provide Disk DiskEncryptionSecretUrl and DiskEncryptionVaultId.");
                }
                return diskEncryptionInfo;
            }
            return null;
        }
    }
}
