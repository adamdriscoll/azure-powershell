// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models
{
    using System.Linq;

    /// <summary>
    /// Hyper V Replica Azure provider specific settings.
    /// </summary>
    [Newtonsoft.Json.JsonObject("HyperVReplicaAzure")]
    public partial class HyperVReplicaAzureReplicationDetails : ReplicationProviderSpecificSettings
    {
        /// <summary>
        /// Initializes a new instance of the HyperVReplicaAzureReplicationDetails class.
        /// </summary>
        public HyperVReplicaAzureReplicationDetails()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the HyperVReplicaAzureReplicationDetails class.
        /// </summary>

        /// <param name="azureVMDiskDetails">Azure VM Disk details.
        /// </param>

        /// <param name="recoveryAzureVMName">Recovery Azure given name.
        /// </param>

        /// <param name="recoveryAzureVMSize">The Recovery Azure VM size.
        /// </param>

        /// <param name="recoveryAzureStorageAccount">The recovery Azure storage account.
        /// </param>

        /// <param name="recoveryAzureLogStorageAccountId">The ARM id of the log storage account used for replication. This will be
        /// set to null if no log storage account was provided during enable
        /// protection.
        /// </param>

        /// <param name="lastReplicatedTime">The Last replication time.
        /// </param>

        /// <param name="rpoInSeconds">Last RPO value.
        /// </param>

        /// <param name="lastRpoCalculatedTime">The last RPO calculated time.
        /// </param>

        /// <param name="vmId">The virtual machine Id.
        /// </param>

        /// <param name="vmProtectionState">The protection state for the vm.
        /// </param>

        /// <param name="vmProtectionStateDescription">The protection state description for the vm.
        /// </param>

        /// <param name="initialReplicationDetails">Initial replication details.
        /// </param>

        /// <param name="vmNics">The PE Network details.
        /// </param>

        /// <param name="selectedRecoveryAzureNetworkId">The selected recovery azure network Id.
        /// </param>

        /// <param name="selectedSourceNicId">The selected source nic Id which will be used as the primary nic during
        /// failover.
        /// </param>

        /// <param name="encryption">The encryption info.
        /// </param>

        /// <param name="osDetails">The operating system info.
        /// </param>

        /// <param name="sourceVMRamSizeInMb">The RAM size of the VM on the primary side.
        /// </param>

        /// <param name="sourceVMCpuCount">The CPU count of the VM on the primary side.
        /// </param>

        /// <param name="enableRdpOnTargetOption">The selected option to enable RDP\SSH on target vm after failover. String
        /// value of SrsDataContract.EnableRDPOnTargetOption enum.
        /// </param>

        /// <param name="recoveryAzureResourceGroupId">The target resource group Id.
        /// </param>

        /// <param name="recoveryAvailabilitySetId">The recovery availability set Id.
        /// </param>

        /// <param name="targetAvailabilityZone">The target availability zone.
        /// </param>

        /// <param name="targetProximityPlacementGroupId">The target proximity placement group Id.
        /// </param>

        /// <param name="useManagedDisks">A value indicating whether managed disks should be used during failover.
        /// </param>

        /// <param name="licenseType">License Type of the VM to be used.
        /// </param>

        /// <param name="sqlServerLicenseType">The SQL Server license type.
        /// </param>

        /// <param name="linuxLicenseType">The license type for Linux VM&#39;s.
        /// Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;LinuxServer&#39;</param>

        /// <param name="lastRecoveryPointReceived">The last recovery point received time.
        /// </param>

        /// <param name="targetVMTags">The target VM tags.
        /// </param>

        /// <param name="seedManagedDiskTags">The tags for the seed managed disks.
        /// </param>

        /// <param name="targetManagedDiskTags">The tags for the target managed disks.
        /// </param>

        /// <param name="targetNicTags">The tags for the target NICs.
        /// </param>

        /// <param name="protectedManagedDisks">The list of protected managed disks.
        /// </param>

        /// <param name="allAvailableOSUpgradeConfigurations">A value indicating all available inplace OS Upgrade configurations.
        /// </param>

        /// <param name="targetVMSecurityProfile">The target VM security profile.
        /// </param>
        public HyperVReplicaAzureReplicationDetails(System.Collections.Generic.IList<AzureVmDiskDetails> azureVMDiskDetails = default(System.Collections.Generic.IList<AzureVmDiskDetails>), string recoveryAzureVMName = default(string), string recoveryAzureVMSize = default(string), string recoveryAzureStorageAccount = default(string), string recoveryAzureLogStorageAccountId = default(string), System.DateTime? lastReplicatedTime = default(System.DateTime?), long? rpoInSeconds = default(long?), System.DateTime? lastRpoCalculatedTime = default(System.DateTime?), string vmId = default(string), string vmProtectionState = default(string), string vmProtectionStateDescription = default(string), InitialReplicationDetails initialReplicationDetails = default(InitialReplicationDetails), System.Collections.Generic.IList<VMNicDetails> vmNics = default(System.Collections.Generic.IList<VMNicDetails>), string selectedRecoveryAzureNetworkId = default(string), string selectedSourceNicId = default(string), string encryption = default(string), OSDetails osDetails = default(OSDetails), int? sourceVMRamSizeInMb = default(int?), int? sourceVMCpuCount = default(int?), string enableRdpOnTargetOption = default(string), string recoveryAzureResourceGroupId = default(string), string recoveryAvailabilitySetId = default(string), string targetAvailabilityZone = default(string), string targetProximityPlacementGroupId = default(string), string useManagedDisks = default(string), string licenseType = default(string), string sqlServerLicenseType = default(string), string linuxLicenseType = default(string), System.DateTime? lastRecoveryPointReceived = default(System.DateTime?), System.Collections.Generic.IDictionary<string, string> targetVMTags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IDictionary<string, string> seedManagedDiskTags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IDictionary<string, string> targetManagedDiskTags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IDictionary<string, string> targetNicTags = default(System.Collections.Generic.IDictionary<string, string>), System.Collections.Generic.IList<HyperVReplicaAzureManagedDiskDetails> protectedManagedDisks = default(System.Collections.Generic.IList<HyperVReplicaAzureManagedDiskDetails>), System.Collections.Generic.IList<OSUpgradeSupportedVersions> allAvailableOSUpgradeConfigurations = default(System.Collections.Generic.IList<OSUpgradeSupportedVersions>), SecurityProfileProperties targetVMSecurityProfile = default(SecurityProfileProperties))

        {
            this.AzureVMDiskDetails = azureVMDiskDetails;
            this.RecoveryAzureVMName = recoveryAzureVMName;
            this.RecoveryAzureVMSize = recoveryAzureVMSize;
            this.RecoveryAzureStorageAccount = recoveryAzureStorageAccount;
            this.RecoveryAzureLogStorageAccountId = recoveryAzureLogStorageAccountId;
            this.LastReplicatedTime = lastReplicatedTime;
            this.RpoInSeconds = rpoInSeconds;
            this.LastRpoCalculatedTime = lastRpoCalculatedTime;
            this.VMId = vmId;
            this.VMProtectionState = vmProtectionState;
            this.VMProtectionStateDescription = vmProtectionStateDescription;
            this.InitialReplicationDetails = initialReplicationDetails;
            this.VMNics = vmNics;
            this.SelectedRecoveryAzureNetworkId = selectedRecoveryAzureNetworkId;
            this.SelectedSourceNicId = selectedSourceNicId;
            this.Encryption = encryption;
            this.OSDetails = osDetails;
            this.SourceVMRamSizeInMb = sourceVMRamSizeInMb;
            this.SourceVMCpuCount = sourceVMCpuCount;
            this.EnableRdpOnTargetOption = enableRdpOnTargetOption;
            this.RecoveryAzureResourceGroupId = recoveryAzureResourceGroupId;
            this.RecoveryAvailabilitySetId = recoveryAvailabilitySetId;
            this.TargetAvailabilityZone = targetAvailabilityZone;
            this.TargetProximityPlacementGroupId = targetProximityPlacementGroupId;
            this.UseManagedDisks = useManagedDisks;
            this.LicenseType = licenseType;
            this.SqlServerLicenseType = sqlServerLicenseType;
            this.LinuxLicenseType = linuxLicenseType;
            this.LastRecoveryPointReceived = lastRecoveryPointReceived;
            this.TargetVMTags = targetVMTags;
            this.SeedManagedDiskTags = seedManagedDiskTags;
            this.TargetManagedDiskTags = targetManagedDiskTags;
            this.TargetNicTags = targetNicTags;
            this.ProtectedManagedDisks = protectedManagedDisks;
            this.AllAvailableOSUpgradeConfigurations = allAvailableOSUpgradeConfigurations;
            this.TargetVMSecurityProfile = targetVMSecurityProfile;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets azure VM Disk details.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "azureVmDiskDetails")]
        public System.Collections.Generic.IList<AzureVmDiskDetails> AzureVMDiskDetails {get; set; }

        /// <summary>
        /// Gets or sets recovery Azure given name.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryAzureVmName")]
        public string RecoveryAzureVMName {get; set; }

        /// <summary>
        /// Gets or sets the Recovery Azure VM size.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryAzureVMSize")]
        public string RecoveryAzureVMSize {get; set; }

        /// <summary>
        /// Gets or sets the recovery Azure storage account.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryAzureStorageAccount")]
        public string RecoveryAzureStorageAccount {get; set; }

        /// <summary>
        /// Gets or sets the ARM id of the log storage account used for replication.
        /// This will be set to null if no log storage account was provided during
        /// enable protection.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryAzureLogStorageAccountId")]
        public string RecoveryAzureLogStorageAccountId {get; set; }

        /// <summary>
        /// Gets or sets the Last replication time.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "lastReplicatedTime")]
        public System.DateTime? LastReplicatedTime {get; set; }

        /// <summary>
        /// Gets or sets last RPO value.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "rpoInSeconds")]
        public long? RpoInSeconds {get; set; }

        /// <summary>
        /// Gets or sets the last RPO calculated time.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "lastRpoCalculatedTime")]
        public System.DateTime? LastRpoCalculatedTime {get; set; }

        /// <summary>
        /// Gets or sets the virtual machine Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vmId")]
        public string VMId {get; set; }

        /// <summary>
        /// Gets or sets the protection state for the vm.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vmProtectionState")]
        public string VMProtectionState {get; set; }

        /// <summary>
        /// Gets or sets the protection state description for the vm.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vmProtectionStateDescription")]
        public string VMProtectionStateDescription {get; set; }

        /// <summary>
        /// Gets or sets initial replication details.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "initialReplicationDetails")]
        public InitialReplicationDetails InitialReplicationDetails {get; set; }

        /// <summary>
        /// Gets or sets the PE Network details.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "vmNics")]
        public System.Collections.Generic.IList<VMNicDetails> VMNics {get; set; }

        /// <summary>
        /// Gets or sets the selected recovery azure network Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "selectedRecoveryAzureNetworkId")]
        public string SelectedRecoveryAzureNetworkId {get; set; }

        /// <summary>
        /// Gets or sets the selected source nic Id which will be used as the primary
        /// nic during failover.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "selectedSourceNicId")]
        public string SelectedSourceNicId {get; set; }

        /// <summary>
        /// Gets or sets the encryption info.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "encryption")]
        public string Encryption {get; set; }

        /// <summary>
        /// Gets or sets the operating system info.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "oSDetails")]
        public OSDetails OSDetails {get; set; }

        /// <summary>
        /// Gets or sets the RAM size of the VM on the primary side.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sourceVmRamSizeInMB")]
        public int? SourceVMRamSizeInMb {get; set; }

        /// <summary>
        /// Gets or sets the CPU count of the VM on the primary side.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sourceVmCpuCount")]
        public int? SourceVMCpuCount {get; set; }

        /// <summary>
        /// Gets or sets the selected option to enable RDP\SSH on target vm after
        /// failover. String value of SrsDataContract.EnableRDPOnTargetOption enum.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "enableRdpOnTargetOption")]
        public string EnableRdpOnTargetOption {get; set; }

        /// <summary>
        /// Gets or sets the target resource group Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryAzureResourceGroupId")]
        public string RecoveryAzureResourceGroupId {get; set; }

        /// <summary>
        /// Gets or sets the recovery availability set Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "recoveryAvailabilitySetId")]
        public string RecoveryAvailabilitySetId {get; set; }

        /// <summary>
        /// Gets or sets the target availability zone.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetAvailabilityZone")]
        public string TargetAvailabilityZone {get; set; }

        /// <summary>
        /// Gets or sets the target proximity placement group Id.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetProximityPlacementGroupId")]
        public string TargetProximityPlacementGroupId {get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether managed disks should be used during
        /// failover.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "useManagedDisks")]
        public string UseManagedDisks {get; set; }

        /// <summary>
        /// Gets or sets license Type of the VM to be used.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "licenseType")]
        public string LicenseType {get; set; }

        /// <summary>
        /// Gets or sets the SQL Server license type.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "sqlServerLicenseType")]
        public string SqlServerLicenseType {get; set; }

        /// <summary>
        /// Gets or sets the license type for Linux VM&#39;s. Possible values include: &#39;NotSpecified&#39;, &#39;NoLicenseType&#39;, &#39;LinuxServer&#39;
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "linuxLicenseType")]
        public string LinuxLicenseType {get; set; }

        /// <summary>
        /// Gets the last recovery point received time.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "lastRecoveryPointReceived")]
        public System.DateTime? LastRecoveryPointReceived {get; private set; }

        /// <summary>
        /// Gets or sets the target VM tags.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetVmTags")]
        public System.Collections.Generic.IDictionary<string, string> TargetVMTags {get; set; }

        /// <summary>
        /// Gets or sets the tags for the seed managed disks.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "seedManagedDiskTags")]
        public System.Collections.Generic.IDictionary<string, string> SeedManagedDiskTags {get; set; }

        /// <summary>
        /// Gets or sets the tags for the target managed disks.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetManagedDiskTags")]
        public System.Collections.Generic.IDictionary<string, string> TargetManagedDiskTags {get; set; }

        /// <summary>
        /// Gets or sets the tags for the target NICs.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetNicTags")]
        public System.Collections.Generic.IDictionary<string, string> TargetNicTags {get; set; }

        /// <summary>
        /// Gets or sets the list of protected managed disks.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "protectedManagedDisks")]
        public System.Collections.Generic.IList<HyperVReplicaAzureManagedDiskDetails> ProtectedManagedDisks {get; set; }

        /// <summary>
        /// Gets or sets a value indicating all available inplace OS Upgrade
        /// configurations.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "allAvailableOSUpgradeConfigurations")]
        public System.Collections.Generic.IList<OSUpgradeSupportedVersions> AllAvailableOSUpgradeConfigurations {get; set; }

        /// <summary>
        /// Gets or sets the target VM security profile.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "targetVmSecurityProfile")]
        public SecurityProfileProperties TargetVMSecurityProfile {get; set; }
    }
}