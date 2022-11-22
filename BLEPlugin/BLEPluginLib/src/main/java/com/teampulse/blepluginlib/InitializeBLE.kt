package com.teampulse.blepluginlib

import android.bluetooth.BluetoothAdapter
import android.bluetooth.BluetoothDevice
import android.app.Activity
import android.bluetooth.BluetoothGatt
import android.bluetooth.BluetoothManager
import android.bluetooth.le.ScanCallback
import android.bluetooth.le.ScanResult
import android.content.Context
import java.util.logging.Handler

class InitializeBLE {

    private var context: Activity? = null;
    private var bluetoothAdapter: BluetoothAdapter?= null;

    fun setContext(context: Activity){
        println("Main Thread ID: ${Thread.currentThread().getId()}");
        println("Setting context");
        this.context = context;
        val bluetoothManager = context.getSystemService(Context.BLUETOOTH_SERVICE) as BluetoothManager;
        bluetoothAdapter = bluetoothManager.adapter;
    }

    private val bluetoothLeScanner = bluetoothAdapter?.bluetoothLeScanner;
    private var scanning = false;
    //private val handler = Handler();

    fun scanDevices(){

    }


}

/*
class BluetoothService {

    private var context: Activity? = null
    private var tagConnection: BluetoothGatt? = null
    private var bluetoothAdapter: BluetoothAdapter? = null
    private var tagIsConnected = true

    fun setContext(context: Activity){
        println("Main Thread ID: ${Thread.currentThread().getId()}")     // ID: 149
        println("Setting context")
        this.context = context
        val bluetoothManager = context.getSystemService(Context.BLUETOOTH_SERVICE) as BluetoothManager
        bluetoothAdapter = bluetoothManager.adapter
    }

    fun scanLeDevice() {
        val scanner = bluetoothAdapter?.bluetoothLeScanner
        println("Thread ID: ${Thread.currentThread().getId()}")    // ID: 149
        println("Scan started")
// UP UNTIL HERE EVERYTHING IS CALLED PROPERLY

        scanner?.startScan(object: ScanCallback(){
            // STARTING FROM HERE THIS CALLBACK FUNCTION IS ONLY CALLED AFTER THE HOMEBUTTON WAS PRESSED
            override fun onScanResult(callbackType: Int, result: ScanResult?) {
                println("New scan result")
                println("Thread ID: ${Thread.currentThread().getId()}")    // ID: 2
                super.onScanResult(callbackType, result)
                val device = result?.device
                if (device?.address == TAG_MAC){
                    println("Found tag")
                    scanner.stopScan(this)
                    device.connectGatt(context, false, gattCallback)
                }
            }

            override fun onScanFailed(errorCode: Int) {
                println("Scan failed")
                println(errorCode.toString())
            }
        })
    }
}*/